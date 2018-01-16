using System;
using System.Linq;
using System.Text;
using Neo.Cryptography;
using Neo.Wallets;

namespace Neo.AspNetCore
{
    public static class KeyPairExtensions
    {
        /// <summary>
        /// Get the public wallet address from a key pair
        /// </summary>
        /// <param name="keyPair">The key pair object to generate the public address for</param>
        /// <returns>The wallet address as a hexadecimal string</returns>
        public static string ToAddress(this KeyPair keyPair)
        {
            var signatureScript = "21" + keyPair.PrivateKey.ToHexString() + "ac";
            var signatureHash = Crypto.Default.Hash160(Encoding.UTF8.GetBytes(signatureScript));

            var data = new byte[21];
            data[0] = 23;
            Buffer.BlockCopy(signatureHash.ToArray(), 0, data, 1, 20);
            var address = data.Base58CheckEncode();

            return address;
        }
    }
}
