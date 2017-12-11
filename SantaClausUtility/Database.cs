using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public sealed class Database
    {
        private static readonly Database _instance = new Database();

        private Database() {}

        public static Database Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
