using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaClausManagement.Util.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util.Tests
{
    [TestClass]
    public class EnumExtensionUnitTest
    {
        [TestMethod]
        public void GetDisplayName_Method_Should_Return_A_String_With_Display_Name_Attribute_If_Present()
        {
            EnumMock enumMock = EnumMock.Element;
            Assert.AreEqual("element", enumMock.GetDisplayName());
        }

        [TestMethod]
        public void GetDisplayName_Method_Should_Return_A_String_Of_The_Object_If_Display_Attribute_Is_Not_Present()
        {
            EnumMock enumMock = EnumMock.AnotherElement;
            Assert.AreEqual(enumMock.ToString(), enumMock.GetDisplayName());
        }
    }
}
