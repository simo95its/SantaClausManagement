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
    public class DatabaseUnitTest
    {
        Database db;
        
        [TestInitialize]
        public void Initialize()
        {
            db = new Database(typeof(MongoDataConnectionMock));
        }

        [TestMethod]
        public void Constructor_With_Type_Parameter_Should_Instantiate_A_Instance_Of_Database()
        {
            Assert.IsInstanceOfType(db, typeof(Database));
        }

        [TestMethod]
        public void GetUser_Method_Should_Returns_A_User_Instance()
        {
            var email = "santa.claus@santa.com";
            var password = "d0bfa042647102d85b8832efcc3ec6a454d669930092a11a2cf71048b47077f8841ea528a8d9d7acd1c8e945b2c6e9edd346e5de8f168fd63c3ade60bf1796c8";
            var screenName = "SantaTheBest";
            var user = db.GetUser(email, password);
            Assert.AreEqual(screenName, user.ScreenName);
        }
    }
}
