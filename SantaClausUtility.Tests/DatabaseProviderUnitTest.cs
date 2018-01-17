using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using System.Reflection;
using SantaClausUtility.Tests.Mock;
using SantaClausUtility.Database;

namespace SantaClausUtility.Tests
{
    [TestClass]
    public class DatabaseProviderUnitTest
    {
        private AssemblyMock _correctAssemblyMock;
        private AssemblyMock _wrongAssemblyMock;
        private AssemblyMock _reflectionTypeLoadExceptionAssemblyMock;

        [TestInitialize]
        public void Initialize()
        {
            this._correctAssemblyMock = new AssemblyMock();
            this._wrongAssemblyMock = new AssemblyMock("false");
            this._reflectionTypeLoadExceptionAssemblyMock = new AssemblyMock("ReflectionTypeLoadException");
        }

        [TestCleanup]
        public void Cleanup()
        {
            GC.Collect();
        }

        [TestMethod]
        public void CreateConnection_Method_Should_Return_A_IDbConnection_Instance()
        {
            DatabaseProvider dbProviderMock = new DatabaseProvider(this._correctAssemblyMock);
            Assert.IsInstanceOfType(dbProviderMock.CreateConnection(), typeof(IDbConnection));
        }

        [TestMethod]
        public void CreateConnection_Method_Should_Thrown_An_ArgumentNullException_If_ConnectionType_Property_Is_Null()
        {
            DatabaseProvider dbProviderMock = new DatabaseProvider(this._wrongAssemblyMock);
            Assert.ThrowsException<ArgumentNullException>(() => dbProviderMock.CreateConnection());
        }

        [TestMethod]
        public void SetProperties_Method_Called_Inside_Constructor_Should_IsDatabaseProvider_True_If_IDbConnection_Type_Implementation_Is_Available()
        {
            DatabaseProvider dbProvider = new DatabaseProvider(this._correctAssemblyMock);
            Assert.IsTrue(dbProvider.IsDatabaseProvider);
        }

        [TestMethod]
        public void SetProperties_Method_Called_Inside_Constructor_Should_IsDatabaseProvider_False_If_IDbConnection_Type_Implementation_Is_Not_Available()
        {
            DatabaseProvider dbProvider = new DatabaseProvider(this._wrongAssemblyMock);
            Assert.IsFalse(dbProvider.IsDatabaseProvider);
        }

        [TestMethod]
        public void SetProperties_Method_Called_Inside_Constructor_Should_Throw_A_ReflectionTypeLoadException_If_Assembly_Is_Not_Loaded()
        {
            DatabaseProvider dbProvider;
            Assert.ThrowsException<ReflectionTypeLoadException>(() => dbProvider = new DatabaseProvider(this._reflectionTypeLoadExceptionAssemblyMock));
        }
    }
}
