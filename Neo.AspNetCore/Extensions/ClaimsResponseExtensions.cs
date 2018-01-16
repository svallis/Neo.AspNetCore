using System;
using Neo.AspNetCore.Json;

namespace Neo.AspNetCore
{
    public static class ClaimsResponseExtensions
    {
        /// <summary>
        /// Correctly calculate the unclaimed GAS from a claim response
        /// </summary>
        /// <param name="claims">The claim response object</param>
        /// <returns>A proper decimal GAS amount</returns>
        public static decimal GetUnclaimedGas(this ClaimsResponse claims)
        {
            if (claims == null || claims.TotalUnspentClaim == 0) return 0;
            return (decimal)claims.TotalUnspentClaim / 100000000;
        }
    }
}
