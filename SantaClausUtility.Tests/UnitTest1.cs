using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaClausUtility;
using Moq;
using MongoDB.Driver;

namespace SantaClausUtility.Tests
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void Create_Should_Object_DatabaseSettings_Has_Value()
        {
            Mock<Database<IMongoDatabase>> mock = new Mock<Database<IMongoDatabase>>();
            mock.Setup(a => a.Settings.DatabaseHost == string.Empty).Throws<ArgumentException>();
        }
    }
}
