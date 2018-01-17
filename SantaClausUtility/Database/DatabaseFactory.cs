using SantaClausUtility.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Database
{
    public sealed class DatabaseFactory : ReflectionFactory<DatabaseFactory, IDatabaseConnection>
    {
        //private const int COMMAND_TIMEOUT = 30000;

        private readonly Type _connection = typeof(IDatabaseConnection);

        public Dictionary<string, DatabaseProvider> Providers { get; private set; }



        public IDatabaseConnection CreateConnection(string providerName, string connectionString, out Exception exError)
        {
            IDatabaseConnection returnValue = null;
            exError = null;

            try
            {
                if (!this.Providers.Keys.Contains(providerName))
                {
                    throw new Exception("Unknown provider " + providerName);
                }
                DatabaseProvider provider = this.Providers[providerName];
                returnValue = provider.CreateConnection();
                returnValue.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {

                exError = ex;
            }
            return returnValue;
        }


    }
}
