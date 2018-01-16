using System;
using Neo.AspNetCore.Constants;

namespace Neo.AspNetCore
{
    public static class NeoNetworkExtensions
    {
        /// <summary>
        /// Gets the CoZ wallet API host name (including scheme, but not including a trailing slash) for the specified network
        /// </summary>
        /// <param name="network">The specified Neo network</param>
        /// <returns>The API scheme and host</returns>
        public static string GetApiAddress(this NeoNetwork network)
        {
            switch (network)
            {
                case NeoNetwork.MainNet:
                    return Hosts.MainNetApi;

                case NeoNetwork.TestNet:
                    return Hosts.TestNetApi;

                default:
                    throw new ArgumentException("No API server address is known for the specified Neo network.", nameof(network));
            }
        }
    }
}
