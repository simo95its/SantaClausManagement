using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SantaClausUtility
{
    public class DatabaseSettings
    {
        public string DatabaseUser
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseUser"];
            }
        }

        public string DatabaseUserPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseUserPassword"];
            }
        }

        public string DatabaseName {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseName"];
            }
        }

        public string DatabaseHost {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseHost"];
            }
        }

        public string DatabaseHostPort {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseHostPort"];
            }
        }

        public string ConnectionString
        {
            get
            {
                return $"mongodb://{DatabaseUser}:{DatabaseUserPassword}@{DatabaseHost}:{DatabaseHostPort}";
            }
        }
    }
}
