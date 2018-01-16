using System;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Neo.Wallets;
using Neo.AspNetCore.Json;

namespace Neo.AspNetCore
{
    public class NeoService : INeoService
    {
        #region Internal Fields

        private readonly NeoServiceOptions _options;
        private readonly WebClient _http = new WebClient();
        private string _apiHost;

        #endregion

        #region Constructor

        public NeoService(IOptions<NeoServiceOptions> options)
        {
            // save our options into a persistent object
            _options = options.Value;

            // get the network to use from the configuration
            if (!string.IsNullOrEmpty(_options.Network))
            {
                var result = Enum.TryParse<NeoNetwork>(_options.Network, out var network);
                if (!result) throw new Exception($"The value '{_options.Network}' could not be recognised as a Neo network. Use 'MainNet' or 'TestNet'.");
                SetNetwork(network);
            }
        }

        #endregion

        #region Public Properties

        public NeoNetwork Network { get; protected set; }

        public Exception LastException { get; protected set; }
        public string LastError { get; protected set; }

        #endregion

        #region Public Methods

        public bool SetNetwork(NeoNetwork network)
        {
            if (network != Network)
            {
                Network = network;
                _apiHost = network.GetApiAddress();
                return true;
            }

            return false;
        }

        public KeyPair GeneratePrivateKey()
        {
            // generate a new private key from two guids
            // guids are 16 bytes long, so two are generated below and copied into a 32 byte buffer for the private key
            // guid generation is used as they should be generated with better entropy than any standard random number generator
            var privateKeyBytes = new byte[32];
            Buffer.BlockCopy(Guid.NewGuid().ToByteArray(), 0, privateKeyBytes, 0, 16);
            Buffer.BlockCopy(Guid.NewGuid().ToByteArray(), 0, privateKeyBytes, 16, 16);

            // turn the bytes into hex and generate a key pair
            var privateKey = privateKeyBytes.ToHexString();
            var key = new KeyPair(privateKeyBytes);

            return key;
        }

        #endregion

        #region API Calls

        public BalanceResponse GetBalance(string address)
        {
            return ApiRequest<BalanceResponse>($"v2/address/balance/{address}");
        }

        public BalanceResponse GetBalance(KeyPair key)
        {
            return GetBalance(key.ToAddress());
        }

        public ClaimsResponse GetClaims(string address)
        {
            return ApiRequest<ClaimsResponse>($"v2/address/claims/{address}");
        }

        public ClaimsResponse GetClaims(KeyPair key)
        {
            return GetClaims(key.ToAddress());
        }

        public HistoryResponse GetHistory(string address)
        {
            return ApiRequest<HistoryResponse>($"v2/address/history/{address}");
        }

        public HistoryResponse GetHistory(KeyPair key)
        {
            return GetHistory(key.ToAddress());
        }

        public BestNodeResponse GetBestNode()
        {
            return ApiRequest<BestNodeResponse>($"v2/network/best_node");
        }

        public BlockHeightResponse GetBlockHeight()
        {
            return ApiRequest<BlockHeightResponse>($"v2/block/height");
        }

        #endregion

        #region Private Methods

        private bool CheckNetwork()
        {
            // if no neo network has been specified, then we don't know where to direct api calls
            return Network != 0;
        }

        private TResponse ApiRequest<TResponse>(string endpoint)
            where TResponse : Response
        {
            var response = ApiRequest(endpoint);

            return DeserializeResponse<TResponse>(response);
        }

        private string ApiRequest(string endpoint)
        {
            if (!CheckNetwork()) throw new Exception("A Neo network must be specified before calling this method.");

            try
            {
                return _http.DownloadString($"{_apiHost}/{endpoint}");
            }
            catch (Exception ex)
            {
                LastException = ex;
                LastError = ex.Message;
                return null;
            }
        }

        private TResponse DeserializeResponse<TResponse>(string response)
            where TResponse: Response
        {
            if (string.IsNullOrEmpty(response)) return null;

            // deserialise the string to a typed object
            var responseObject = JsonConvert.DeserializeObject<TResponse>(response);

            // check that the request and response networks match
            if (responseObject.Net != Network) throw new Exception($"The requested and response networks do not match. Requested '{Network}', response is '{responseObject.Net}'.");

            return responseObject;
        }

        #endregion
    }
}
