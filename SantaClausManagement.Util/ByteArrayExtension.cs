using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SantaClausManagement.Util
{
    public static class ByteArrayExtension
    {
        public static byte[] ToSHA512(this byte[] byteArray)
        {
            return SHA512.Create().ComputeHash(byteArray);
        }

        public static string ToHexStringLowerCase(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray)
                .Replace("-", string.Empty)
                .ToLower();
        }
    }
}
