using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Database
{
    public class DatabaseMapper
    {
        public Dictionary<string, DataMapper<DatabaseEntity>> Mappers { get; private set; }

        private static readonly DatabaseMapper _factory = new DatabaseMapper();

        public static DatabaseMapper GetInstance()
        {
            return _factory;
        }

        private DatabaseMapper()
        {
            this.Mappers = new Dictionary<string, DataMapper<DatabaseEntity>>();

            string location = Assembly.GetExecutingAssembly().Location; //
            string path = Path.GetDirectoryName(location);
            
            List<string> dlls = new List<string>();

            dlls.AddRange(Directory.GetFiles(path, "*data*.dll"));


            foreach (string dll in dlls)
            {
                var assembly = Assembly.LoadFile(dll);

                DatabaseProvider provider = new DatabaseProvider(assembly);

                if (provider.IsDatabaseProvider)
                {
                    this.Providers.Add(provider.Name, provider);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public DatabaseFactory SearchAssemblyForFullyQualifiedName(IEnumerable<Type> types)
        {
            if (this._types.Count > 0)
            {
                this._types.Clear();
            }
            this._types.AddRange(types);
            return this;
        }
    }
}
