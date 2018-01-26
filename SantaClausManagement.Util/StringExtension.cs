using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public static class StringExtension
    {
        public static byte[] FromUTF8StringToByteArray(this string stringUTF8)
        {
            return Encoding.UTF8.GetBytes(stringUTF8);
        }
    }
}
