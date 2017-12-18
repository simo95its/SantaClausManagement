using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SantaClausUtility
{
    public class DatabaseSettings : DatabaseServerSettings
    {
        public string DatabaseName {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseName"];
            }
        }
    }
}
