using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neo.AspNetCore.Json;
using Neo.Wallets;

namespace Neo.AspNetCore.Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INeoService _neo;

        public IndexModel(INeoService neo)
        {
            _neo = neo;
        }

        public BalanceResponse Existing { get; set; }
        public KeyPair GeneratedKey { get; set; }
        public BalanceResponse Generated { get; set; }

        public void OnGet()
        {
            // load the balance from the neo council wallet using their public address
            Existing = _neo.GetBalance("AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i");

            // generate a new random private key, and then get the balance from that
            GeneratedKey = _neo.GeneratePrivateKey();
            Generated = _neo.GetBalance(GeneratedKey.ToAddress());
        }
    }
}
