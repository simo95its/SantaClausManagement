using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SantaClausManagement.Util.Tests.Mock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util.Tests
{
    [TestClass]
    public class MongoDataConnectionUnitTest
    {
        [TestMethod]
        public void Protocol_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("mongodb", mongo.Protocol);
        }

        [TestMethod]
        public void Username_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("simone", mongo.Username);
        }

        [TestMethod]
        public void Password_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("simone", mongo.Password);
        }

        [TestMethod]
        public void Server_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("ds044787.mlab.com", mongo.Server);
        }

        [TestMethod]
        public void Port_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("44787", mongo.Port);
        }

        [TestMethod]
        public void DataIdentifier_Property_Should_Return_A_Value()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.AreEqual("santa_claus_data", mongo.DataIdentifier);
        }

        [TestMethod]
        public void Connection_Property_Should_Return_A_Object_Connection_Instance()
        {
            var mongo = new MongoDataConnectionMock();
            Assert.IsInstanceOfType(mongo.Connection, typeof(object));
        }

        [TestMethod]
        public void Map_Method_Should_Return_A_Dictionary_Mapper()
        {
            var mongo = new MongoDataConnectionMock();
            var mapper = mongo.Map();
            Assert.AreEqual(typeof(User), mapper["users"]);
            Assert.AreEqual(typeof(Order), mapper["orders"]);
            Assert.AreEqual(typeof(Toy), mapper["toys"]);
        }

        [TestMethod]
        public void GetQueryableObject_Method_Should_Return_A_Dictionary_Of_Queryable_Entity()
        {
            var mongo = new MongoDataConnectionMock();
            var queryableList = mongo.GetQueryableObjectsList();
            Assert.IsInstanceOfType(queryableList["users"], typeof(IQueryable));
            Assert.IsInstanceOfType(queryableList["orders"], typeof(IQueryable));
            Assert.IsInstanceOfType(queryableList["toys"], typeof(IQueryable));
        }

        [TestMethod]
        public void Update_Method_Should_Return_True_If_Update_Is_Successful()
        {
            //Da Finire
        }
    }
}
