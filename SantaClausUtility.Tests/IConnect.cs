using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaClausUtility;
using Moq;
using MongoDB.Driver;

namespace SantaClausUtility.Tests
{
    [TestClass]
    public class IConnectUnitTest
    {
        [TestMethod]
        public void Connect_Method_Should_Return_A_Connection()
        {
            Mock<IConnect<DatabaseSettings, IMongoDatabase>> mock = new Mock<IConnect<DatabaseSettings, IMongoDatabase>>();
            mock.Setup(a => a.Connect(It.IsAny<Func<DatabaseSettings, IMongoDatabase>>())).Returns((IMongoDatabase db) => db);
        }
    }
}
