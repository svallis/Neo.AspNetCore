using System;

namespace Neo.AspNetCore.Json
{
    public class BalanceResponse : Response
    {
        public Asset Neo { get; set; }

        public Asset Gas { get; set; }

        public string Address { get; set; }
    }
}
