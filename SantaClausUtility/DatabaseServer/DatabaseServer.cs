using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    //public sealed class DatabaseServer<T> :
    //    IConnect<DatabaseServerSettings, T, DatabaseServer<T>>,
    //    ICRUD<DatabaseServer<T>, DatabaseServerSettings>
    //{
    //    #region Singleton Declaration

    //    private static readonly DatabaseServer<T> _instance = new DatabaseServer<T>();

    //    public static DatabaseServer<T> Instance { get; }

    //    private DatabaseServer()
    //    {
    //        Settings = new DatabaseServerSettings();
    //    }

    //    #endregion

    //    public DatabaseServerSettings Settings { get; }

    //    private static object _syncLock = new object();
    //    private T _connectionInstance;

    //    public DatabaseList Databases { get; private set; }

    //    public DatabaseServer<T> Connect(Func<DatabaseServerSettings, T> connection)
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
    //        return this;
    //    }


    //}
}
