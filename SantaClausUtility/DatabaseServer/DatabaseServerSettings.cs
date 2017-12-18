using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SantaClausUtility
{
    public class DatabaseServerSettings
    {
        public string DatabaseUser
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseServerUser"];
            }
        }

        public string DatabaseUserPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseServerUserPassword"];
            }
        }

        public string DatabaseHost
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseServerHost"];
            }
        }

        public string DatabaseHostPort
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseServerHostPort"];
            }
        }

        /*
        public virtual string ConnectionString
        {
            get
            {
                return $"mongodb://{DatabaseUser}:{DatabaseUserPassword}@{DatabaseHost}:{DatabaseHostPort}";
            }
        }
        */
    }
}
