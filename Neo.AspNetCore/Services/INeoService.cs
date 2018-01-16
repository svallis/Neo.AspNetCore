using System;
using Neo.Wallets;
using Neo.AspNetCore.Json;

namespace Neo.AspNetCore
{
    public interface INeoService
    {
        #region Properties

        /// <summary>
        /// Get the currently set Neo network (MainNet or TestNet)
        /// </summary>
        NeoNetwork Network { get; }

        /// <summary>
        /// The last exception that occured while making an RPC
        /// </summary>
        Exception LastException { get; }

        /// <summary>
        /// The message from the last exception that occured while making an RPC
        /// </summary>
        string LastError { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Set the current Neo network to make queries and transactions against
        /// This change will persist for the duration of the object, which is scoped to the request when using dependency injection
        /// </summary>
        /// <param name="network">The network to switch to</param>
        /// <returns>True if the network was successfully switched</returns>
        bool SetNetwork(NeoNetwork network);

        /// <summary>
        /// Gets the current NEO and GAS balance for the specified wallet address
        /// </summary>
        /// <param name="address">The public address of the wallet to check the balance for</param>
        /// <returns>A balance response object containing NEO and GAS balances</returns>
        BalanceResponse GetBalance(string address);

        /// <summary>
        /// Gets the current NEO and GAS balance for the specified wallet address
        /// </summary>
        /// <param name="key">The key pair representing the wallet to check the balance for</param>
        /// <returns>A balance response object containing NEO and GAS balances</returns>
        BalanceResponse GetBalance(KeyPair key);

        /// <summary>
        /// Gets the current claims for the specified wallet address
        /// </summary>
        /// <param name="address">The public address of the wallet to check the balance for</param>
        /// <returns>A claims response object containing claim information</returns>
        ClaimsResponse GetClaims(string address);

        /// <summary>
        /// Gets the current claims for the specified wallet address
        /// </summary>
        /// <param name="key">The key pair representing the wallet to check the balance for</param>
        /// <returns>A claims response object containing claim information</returns>
        ClaimsResponse GetClaims(KeyPair key);

        /// <summary>
        /// Gets the NEO and GAS transaction history for the specified wallet address
        /// </summary>
        /// <param name="address">The public address of the wallet to check the balance for</param>
        /// <returns>A history response object containing NEO and GAS transactions</returns>
        HistoryResponse GetHistory(string address);

        /// <summary>
        /// Gets the NEO and GAS transaction history for the specified wallet address
        /// </summary>
        /// <param name="key">The key pair representing the wallet to check the balance for</param>
        /// <returns>A history response object containing NEO and GAS transactions</returns>
        HistoryResponse GetHistory(KeyPair key);

        // @todo: make GAS and NEO transactions

        // @todo: get NEP-5 token balances

        // @todo: invoke smart contracts

        // @todo: retrieve smart contract storage data

        /// <summary>
        /// Get the node with the highest performance on the Neo network
        /// </summary>
        /// <returns>A best node response object containing the best node</returns>
        BestNodeResponse GetBestNode();

        /// <summary>
        /// Gets the current height of the blockchain
        /// </summary>
        /// <returns>A block height response object containing the blockchain height</returns>
        BlockHeightResponse GetBlockHeight();

        /// <summary>
        /// Generates a new KeyPair based on a randomly generated private key
        /// </summary>
        /// <returns>The newly generated key pair</returns>
        KeyPair GeneratePrivateKey();

        #endregion
    }
}
