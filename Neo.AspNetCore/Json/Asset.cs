using System;

namespace Neo.AspNetCore.Json
{
    public class Asset
    {
        public decimal Balance { get; set; }

        public Unspent[] Unspent { get; set; }
    }
}
