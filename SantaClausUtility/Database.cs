using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public sealed class Database<T> : IConnect<Database<T>.DatabaseSettings, T>, ICRUD<Database<T>, Database<T>.DatabaseSettings>
    {
        #region Singleton Declaration

        private static readonly Database<T> _instance = new Database<T>();

        public static Database<T> Instance { get; }

        private Database()
        {
            _connectionInstance = Connect(); //TODO
        }

        #endregion  

        private class DatabaseSettings
        {
            public string DatabaseUser { get; set; }
            public string DatabaseUserPassword { get; set; }
            public string DatabaseName { get; set; }
            public string DatabaseHost { get; set; }
            public string DatabaseHostPort { get; set; }
        }

        private DatabaseSettings Settings { get; set; }
        private T _connectionInstance;

        Database<T> ICRUD<Database<T>, DatabaseSettings>.Index()
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Database<T>, DatabaseSettings>.Create(Database<T> element)
        {
            throw new NotImplementedException();
        }

        Database<T> ICRUD<Database<T>, DatabaseSettings>.Read(DatabaseSettings id)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Database<T>, DatabaseSettings>.Update(Database<T> element)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Database<T>, DatabaseSettings>.Delete(DatabaseSettings id)
        {
            throw new NotImplementedException();
        }

        T IConnect<DatabaseSettings, T>.Connect(Func<DatabaseSettings, T> connection)
        {
            return connection(Settings);
        }
    }
}
