using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SantaClausUtility.Database
{
    public abstract class DataMapper<T>
    {
        public IDbConnection Connection { get; private set; }

        public DataMapper(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("A valid database connection is required");
            }
            this.Connection = connection;
        }

        public abstract List<T> Select(out Exception exError);

        public abstract bool Create(T instance, out Exception exError);

        public abstract T Read(int ID, out Exception exError);

        public abstract T Read(T instance, out Exception exError);

        public abstract bool Update(T instance, out Exception exError);

        public abstract bool Delete(int ID, out Exception exError);

        public abstract bool Delete(T instance, out Exception exError);
    }
}
