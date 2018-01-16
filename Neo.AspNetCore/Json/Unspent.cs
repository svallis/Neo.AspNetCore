using System;

namespace Neo.AspNetCore.Json
{
    public class Unspent
    {
        public int Index { get; set; }

        public string TxId { get; set; }

        public decimal Value { get; set; }
    }
}
