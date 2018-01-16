using System;
using Newtonsoft.Json;

namespace Neo.AspNetCore.Json
{
    public class HistoryResponse : Response
    {
        public string Address { get; set; }

        public Transaction[] History { get; set; }

        public string Name { get; set; }
    }
}
