using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Linq;

namespace SantaClausManagement.Util.Tests
{
    [TestClass]
    public class ByteArrayExtensionUnitTest
    {
        [TestMethod]
        public void ToSHA512_Method_Should_Return_A_Byte_Array_Hashed()
        {
            string test = "test";
            string hashOfTestString = "EE26B0DD4AF7E749AA1A8EE3C10AE9923F618980772E473F8819A5D4940E0DB27AC185F8A0E1D5F84F88BC887FD67B143732C304CC5FA9AD8E6F57F50028A8FF";
            Assert.AreEqual(hashOfTestString, test.FromUTF8StringToByteArray().ToSHA512().ToHexStringLowerCase().ToUpper());
        }

        [TestMethod]
        public void ToHexStringLowerCase_Method_Should_Return_A_Hexadecimal_String_Of_The_Byte_Array()
        {
            byte[] number = new byte[] { 255 };
            Console.WriteLine(number.ToHexStringLowerCase());
            Assert.AreEqual("ff", number.ToHexStringLowerCase());
        }
    }
}
