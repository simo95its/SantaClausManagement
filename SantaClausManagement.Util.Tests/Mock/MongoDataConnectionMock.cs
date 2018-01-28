using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util.Tests.Mock
{
    public class MongoDataConnectionMock : MongoDataConnection
    {
        public override object Connection
        {
            get
            {
                return new DataMock();
            }
        }

        public override Dictionary<string, IQueryable> GetQueryableObjectsList()
        {
            var queryableDictionary = new Dictionary<string, IQueryable>();
            var conn = Connection as DataMock;
            queryableDictionary.Add("users", conn.Users.AsQueryable());
            queryableDictionary.Add("orders", conn.Orders.AsQueryable());
            queryableDictionary.Add("toys", conn.Toys.AsQueryable());
            return queryableDictionary;
        }

        /*
        public override Dictionary<string, Type> Map()
        {
            JSchema userSchema = new JSchema()
            {
                Type = JSchemaType.Array,
                Items =
                {
                    new JSchema
                    {
                        Type = JSchemaType.Object,
                        Properties =
                        {
                            {"_id", new JSchema {Type = JSchemaType.String} },
                            {"screenname", new JSchema {Type = JSchemaType.String } },
                            {"email", new JSchema {Type = JSchemaType.String} },
                            {"isAdmin", new JSchema {Type = JSchemaType.Boolean} },
                            {"password", new JSchema {Type = JSchemaType.String}},
                            {"password_clear_text", new JSchema {Type=JSchemaType.String} }
                        }
                    }

                },
            };

            JSchema toySchema = new JSchema()
            {
                Type = JSchemaType.Array,
                Items =
                {
                    new JSchema
                    {
                        Type = JSchemaType.Object,
                        Properties =
                        {
                            {"_id", new JSchema {Type = JSchemaType.String} },
                            {"name", new JSchema {Type = JSchemaType.String} },
                            {"cost", new JSchema {Type = JSchemaType.Number} },
                            {"amount", new JSchema {Type = JSchemaType.Number} }
                        }
                    }
                }
            };

            JSchema orderSchema = new JSchema()
            {
                Type = JSchemaType.Array,
                Items =
                {
                    new JSchema
                    {
                        Type = JSchemaType.Object,
                        Properties =
                        {
                            {"_id", new JSchema {Type = JSchemaType.String} },
                            {"kid", new JSchema {Type = JSchemaType.String } },
                            {"status", new JSchema { Type = JSchemaType.Number} },
                            {"toys",
                                new JSchema
                                {
                                    Type = JSchemaType.Array,
                                    Items =
                                    {
                                        new JSchema
                                        {
                                            Type = JSchemaType.Object,
                                            Properties =
                                            {
                                                {"name", new JSchema {Type = JSchemaType.String} }
                                            }
                                        }
                                    }
                                }
                            },
                            {"requestDate", new JSchema {Type = JSchemaType.String} }
                        }
                    }
                }
            };
        }
        */

        /*
        public override bool Update<TypeEntity, TypeProperty>(string id, string propertyName, TypeProperty value)
        {
            Type type = typeof(TypeEntity);
            var typeMappedQuery = from tm in _mapper
                                  where tm.Value == type
                                  select tm.Key;
            var typeMapped = typeMappedQuery.Single();

            var entity = GetQueryableObjectsList()[typeMapped];
            


            var item = conn.Orders;
            //var result = item.;
            //TypeProperty property = (TypeProperty)result.GetType().GetProperty(propertyName).GetValue(result);
            return true;//result != null ? true : false;
        }
        */
    }
}
