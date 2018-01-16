using System;
using Newtonsoft.Json;

namespace Neo.AspNetCore.Json
{
    public class ClaimsResponse : Response
    {
        public string Address { get; set; }

        // @todo: claims collection

        [JsonProperty("total_claim")]
        public Int64 TotalClaim { get; set; }

        [JsonProperty("total_unspent_claim")]
        public Int64 TotalUnspentClaim { get; set; }
    }
}
