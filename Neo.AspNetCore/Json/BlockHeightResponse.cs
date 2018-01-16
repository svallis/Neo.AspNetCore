using System;
using Newtonsoft.Json;

namespace Neo.AspNetCore.Json
{
    public class BlockHeightResponse : Response
    {
        [JsonProperty("block_height")]
        public int BlockHeight { get; set; }
    }
}
