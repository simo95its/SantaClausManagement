using SantaClausUtility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SantaClausUtility.Mapper
{
    public class UserDataMapper : DataMapper<User>
    {
        public UserDataMapper(IDbConnection connection) : base(connection) { }

        public override bool Create(User instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(User instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override User Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override User Read(User instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override List<User> Select(out Exception exError)
        {
            List<User> returnValue = new List<User>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (IDbCommand command = this.Connection.CreateCommand())
                {
                    command.CommandText = "SELECT [UserID], [Username] FROM dbo.[User]";
                    command.CommandType = CommandType.Text;

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            returnValue.Add(new User() { UserID = reader.GetInt32(0), Username = reader.GetString(1) });
                    }
                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }
            catch (Exception ex)
            {
                exError = ex;
            }

            return returnValue;
        }

        public override bool Update(User instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}
