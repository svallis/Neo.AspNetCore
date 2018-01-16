using System;
using System.Text;
using System.Collections.Generic;

namespace Neo.AspNetCore
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Convert an enumerable collection of bytes into a hexadecimal string
        /// </summary>
        /// <param name="bytes">The enumerable collection of bytes</param>
        /// <param name="length">The number of bytes being converted. If specified, allows the string to be pre-allocated to the correct size</param>
        /// <returns>The converted hexadecimal string</returns>
        public static string ToHexString(this IEnumerable<byte> bytes, int? length = null)
        {
            // early out
            if (bytes == null) return null;

            // pre-size allocation if we can
            var sb = length.HasValue ? new StringBuilder(length.Value * 2) : new StringBuilder();

            // loop through bytes and output
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
