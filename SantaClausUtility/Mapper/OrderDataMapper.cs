using SantaClausUtility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SantaClausUtility.Mapper
{
    public class OrderDataMapper : DataMapper<Order>
    {
        public OrderDataMapper(IDbConnection connection) : base(connection) { }

        public override bool Create(Order instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Order instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Order Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Order Read(Order instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override List<Order> Select(out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Order instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}
