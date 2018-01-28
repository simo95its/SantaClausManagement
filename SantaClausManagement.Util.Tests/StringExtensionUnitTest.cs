using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaClausManagement.Util;
using System.Text;

namespace SantaClausManagement.Util.Tests
{
    [TestClass]
    public class StringExtensionUnitTest
    {
        [TestMethod]
        public void FromUTF8StringToByteArray_Method_Should_Returns_A_Byte_Array_Of_The_String()
        {
            string stringTest = "test";
            byte[] byteArrayTest = stringTest.FromUTF8StringToByteArray();
            Assert.AreEqual(stringTest, Encoding.UTF8.GetString(byteArrayTest));
        }
    }
}
