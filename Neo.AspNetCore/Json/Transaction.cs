using System;
using Newtonsoft.Json;

namespace Neo.AspNetCore.Json
{
    public class Transaction
    {
        public decimal Gas { get; set; }

        public decimal Neo { get; set; }

        [JsonProperty("block_index")]
        public int BlockIndex { get; set; }

        [JsonProperty("gas_sent")]
        public bool GasSent { get; set; }

        [JsonProperty("neo_sent")]
        public bool NeoSent { get; set; }

        public string TxId { get; set; }
    }
}
