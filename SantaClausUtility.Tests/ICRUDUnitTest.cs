using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausUtility.Tests
{
    [TestClass]
    public class ICRUDUnitTest
    {
        [TestMethod]
        public void Create_Method_Should_Return_A_IMongoDatabase_Instance()
        {
            Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>> mock = new Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>>();
            mock.Setup(a => a.Create(It.IsAny<Func<DatabaseSettings, Database<IMongoDatabase>>>(), It.IsAny<DatabaseSettings>())).Returns((Database<IMongoDatabase> db) => db);
        }

        [TestMethod]
        public void Read_Method_Should_Return_A_IMongoDatabase_Instance()
        {
            Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>> mock = new Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>>();
            mock.Setup(a => a.Read(It.IsAny<Func<DatabaseSettings, Database<IMongoDatabase>>>(), It.IsAny<DatabaseSettings>())).Returns((Database<IMongoDatabase> db) => db);
        }

        [TestMethod]
        public void Update_Method_Should_Return_A_IMongoDatabase_Instance()
        {
            Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>> mock = new Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>>();
            mock.Setup(a => a.Update(It.IsAny<Func<DatabaseSettings, Database<IMongoDatabase>>>(), It.IsAny<DatabaseSettings>())).Returns((Database<IMongoDatabase> db) => db);
        }

        [TestMethod]
        public void Delete_Method_Should_Return_A_IMongoDatabase_Instance()
        {
            Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>> mock = new Mock<ICRUD<Database<IMongoDatabase>, DatabaseSettings>>();
            mock.Setup(a => a.Delete(It.IsAny<Func<DatabaseSettings, Database<IMongoDatabase>>>(), It.IsAny<DatabaseSettings>())).Returns((Database<IMongoDatabase> db) => db);
        }
    }
}
