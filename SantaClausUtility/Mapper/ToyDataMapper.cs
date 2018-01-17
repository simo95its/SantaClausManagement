using SantaClausUtility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SantaClausUtility.Mapper
{
    public class ToyDataMapper : DataMapper<Toy>
    {
        public ToyDataMapper(IDbConnection connection) : base(connection) { }

        public override bool Create(Toy instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Toy instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Toy Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Toy Read(Toy instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override List<Toy> Select(out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Toy instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}
