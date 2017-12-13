using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SantaClausUtility
{
    public sealed class Database<T, TypeEntity> : IConnect<Database<T, TypeEntity>.DatabaseSettings, T>, ICRUD<Database<T, TypeEntity>, Database<T, TypeEntity>.DatabaseSettings>
    {
        #region Singleton Declaration

        private static readonly Database<T, TypeEntity> _instance = new Database<T, TypeEntity>();

        public static Database<T, TypeEntity> Instance { get; }

        private Database() {}

        #endregion  

        public class DatabaseSettings
        {
            public string DatabaseUser { get; set; }
            public string DatabaseUserPassword { get; set; }
            public string DatabaseName { get; set; }
            public string DatabaseHost { get; set; }
            public string DatabaseHostPort { get; set; }
        }

        public DatabaseSettings Settings { get; set; }

        private static object _syncLock = new object();
        private T _connectionInstance;

        private List<TypeEntity> Entities { get; set; }

        T IConnect<DatabaseSettings, T>.Connect(Func<DatabaseSettings, T> connection)
        {
            if (_connectionInstance == null)
            {
                lock (_syncLock)
                {
                    if (_connectionInstance == null)
                    {
                        _connectionInstance = connection(Settings);
                    }
                }
            }
            return _connectionInstance;
        }

        bool ICRUD<Database<T, TypeEntity>, DatabaseSettings>.Create(Func<DatabaseSettings, bool> creation, OptionalAttribute element)
        {
            return creation(Settings);
        }

        Database<T, TypeEntity> ICRUD<Database<T, TypeEntity>, DatabaseSettings>.Read(Func<DatabaseSettings, Database<T, TypeEntity>> read, OptionalAttribute id)
        {
            return read(Settings);
        }

        bool ICRUD<Database<T, TypeEntity>, DatabaseSettings>.Update(Func<DatabaseSettings, bool> update, OptionalAttribute element)
        {
            return update(Settings);
        }

        bool ICRUD<Database<T, TypeEntity>, DatabaseSettings>.Delete(Func<DatabaseSettings, bool> deletion, OptionalAttribute element)
        {
            return deletion(Settings);
        }


    }
}
