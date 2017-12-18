using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Linq;

namespace SantaClausUtility
{
    //public sealed class Database<T> : 
    //    IConnect<DatabaseSettings, T, Database<T>>, 
    //    ICRUD<Database<T>, DatabaseSettings>
    //{
    //    #region Singleton Declaration

    //    private static readonly Database<T> _instance = new Database<T>();

    //    public static Database<T> Instance { get; }

    //    private Database() {}

    //    #endregion  

    //    public DatabaseSettings Settings { get; set; }

    //    private static object _syncLock = new object();
    //    private T _connectionInstance;

    //    public DatabaseEntitiesList Entities { get; set; }

    //    T IConnect<DatabaseSettings, T, Database<T>>.Connect(Func<DatabaseSettings, T> connection)
    //    {
    //        if (_connectionInstance == null)
    //        {
    //            lock (_syncLock)
    //            {
    //                if (_connectionInstance == null)
    //                {
    //                    _connectionInstance = connection(Settings);
    //                }
    //            }
    //        }
    //        return _connectionInstance;
    //    }

    //    Database<T> ICRUD<Database<T>, DatabaseSettings>.Create(Func<DatabaseSettings, Database<T>> creation, DatabaseSettings id)
    //    {
    //        return creation(Settings);
    //    }

    //    Database<T> ICRUD<Database<T>, DatabaseSettings>.Read(Func<DatabaseSettings, Database<T>> read, DatabaseSettings id)
    //    {
    //        return read(Settings);
    //    }

    //    Database<T> ICRUD<Database<T>, DatabaseSettings>.Update(Func<DatabaseSettings, Database<T>> update, DatabaseSettings id)
    //    {
    //        return update(Settings);
    //    }

    //    Database<T> ICRUD<Database<T>, DatabaseSettings>.Delete(Func<DatabaseSettings, Database<T>> deletion, DatabaseSettings id)
    //    {
    //        return deletion(Settings);
    //    }
    //}
}
