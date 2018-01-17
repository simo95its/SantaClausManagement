using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public interface IDatabaseConnection : IDisposable
    {
        string ConnectionString { get; set; } //string Obbligatoria

        int ConnectionTimeout { get; set; } //

        string Database { get; set; }

        ConnectionState State { get; set; }

        void ChangeDatabase(string databaseName);

        void Close();

        IDbCommand CreateCommand();

        void Open();
    }
}
