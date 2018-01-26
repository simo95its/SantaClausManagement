using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace SantaClausManagement.Util
{
    internal class MongoDataConnection : IDataConnection
    {
        private Dictionary<string, Type> _mapper = new Dictionary<string, Type>();

        private static bool _isMapped = false;

        public string Protocol
        {
            get => ConfigurationManager.AppSettings["MongoProtocol"];
        }

        public string Username
        {
            get => ConfigurationManager.AppSettings["MongoUsername"];
        }

        public string Password
        {
            get => ConfigurationManager.AppSettings["MongoPassword"];
        }

        public string Server
        {
            get => ConfigurationManager.AppSettings["MongoServer"];
        }

        public string Port
        {
            get => ConfigurationManager.AppSettings ["MongoPort"];
        }

        public string DataIdentifier
        {
            get => ConfigurationManager.AppSettings["MongoDataIdentifier"];
        }

        public object Connection
        {
            get
            {
                return new MongoClient($"{Protocol}://{Username}:{Password}@{Server}:{Port}/{DataIdentifier}").GetDatabase(DataIdentifier);
                
            }
        }

        public Dictionary<string, IQueryable> GetQueryableObjectsList(Dictionary<string, Type> mapper)
        {
                Dictionary<string, IQueryable> queryableObject = new Dictionary<string, IQueryable>();
                /*
                foreach (var type in mapper)
                {
                    MethodInfo method = typeof(IMongoDatabase).GetMethod("GetCollection")
                                        .MakeGenericMethod(type.Value);
                    var collection = method.Invoke(Connection, new object[] { type.Key });
                    var collectionQueryable = collection.GetType().GetMethod("AsQueryable").MakeGenericMethod(type.Value).Invoke(collection, new object[] { });
                    queryableObject.Add(type.Key, (IQueryable)collectionQueryable);
                }
                */
                /**/
                queryableObject.Add("users", ((IMongoDatabase)Connection).GetCollection<User>("users").AsQueryable());
                queryableObject.Add("orders", ((IMongoDatabase)Connection).GetCollection<Order>("orders").AsQueryable());
                queryableObject.Add("toys", ((IMongoDatabase)Connection).GetCollection<Toy>("toys").AsQueryable());
                /**/
                return queryableObject;
        }

        public Dictionary<string, Type> Map()
        {
            Dictionary<string, Type> mapper = new Dictionary<string, Type>();
            mapper.Add("users", typeof(User));
            mapper.Add("orders", typeof(Order));
            mapper.Add("toys", typeof(Toy));

            if (!_isMapped)
            {
                _isMapped = true;
                RegisterUser();
                RegisterToy();
                RegisterOrder();
            }
            
            return mapper;
        }

        private static BsonClassMap<User> RegisterUser()
        {
            return BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.ScreenName).SetElementName("screenname");
                cm.MapMember(c => c.Email).SetElementName("email");
                cm.MapMember(c => c.IsAdmin).SetElementName("isAdmin");
                cm.MapMember(c => c.Password).SetElementName("password");
                cm.MapMember(c => c.PasswordClearText).SetElementName("password_clear_text");
            });

        }

        private static BsonClassMap<Toy> RegisterToy()
        {
            return BsonClassMap.RegisterClassMap<Toy>(cm =>
            {
                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.Name).SetElementName("name");
                cm.MapMember(c => c.Cost).SetIgnoreIfNull(true).SetElementName("cost");
                cm.MapMember(c => c.Amount).SetIgnoreIfNull(true).SetElementName("amount");
            });
        }

        private static BsonClassMap<Order> RegisterOrder()
        {
            return BsonClassMap.RegisterClassMap<Order>(cm =>
            {
                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.Kid).SetElementName("kid");
                cm.MapMember(c => c.Status).SetElementName("status");
                cm.MapMember(c => c.Toys).SetElementName("toys");
                cm.MapMember(c => c.RequestDate).SetElementName("requestDate");
            });
        }
    }
}
