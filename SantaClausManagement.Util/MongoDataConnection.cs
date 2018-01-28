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
    public class MongoDataConnection : IDataConnection
    {
        protected Dictionary<string, Type> _mapper = new Dictionary<string, Type>();

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

        public virtual object Connection
        {
            get
            {
                return new MongoClient($"{Protocol}://{Username}:{Password}@{Server}:{Port}/{DataIdentifier}").GetDatabase(DataIdentifier);
                
            }
        }

        public virtual Dictionary<string, IQueryable> GetQueryableObjectsList()
        {
            Dictionary<string, IQueryable> queryableObject = new Dictionary<string, IQueryable>();

            queryableObject.Add("users", ((IMongoDatabase)Connection).GetCollection<User>("users").AsQueryable());
            queryableObject.Add("orders", ((IMongoDatabase)Connection).GetCollection<Order>("orders").AsQueryable());
            queryableObject.Add("toys", ((IMongoDatabase)Connection).GetCollection<Toy>("toys").AsQueryable());

            return queryableObject;
        }

        public virtual Dictionary<string, Type> Map()
        {
            _mapper.Add("users", typeof(User));
            _mapper.Add("orders", typeof(Order));
            _mapper.Add("toys", typeof(Toy));

            if (!_isMapped)
            {
                _isMapped = true;
                RegisterUser();
                RegisterToy();
                RegisterOrder();
            }
            
            return _mapper;
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

        public virtual bool Update<TypeEntity, TypeProperty>(string id, string propertyName, TypeProperty value)
        {
            Type type = typeof(TypeEntity);
            var typeMappedQuery = from tm in _mapper
                        where tm.Value == type
                        select tm.Key;
            var typeMapped = typeMappedQuery.Single();

            var filter = Builders<TypeEntity>.Filter.Eq("_id", new ObjectId(id));

            var mapQuery = from map in BsonClassMap.GetRegisteredClassMaps()
                           where map.ClassType == typeof(TypeEntity)
                           select map;
            var bsonMap = mapQuery.Single();
            var queryMapMember = from member in bsonMap.DeclaredMemberMaps
                                 where member.MemberName == propertyName
                                 select member.ElementName;
            var elementName = queryMapMember.Single();

            var update = Builders<TypeEntity>.Update.Set(elementName, value);

            var conn = Connection as IMongoDatabase;
            var collection = conn.GetCollection<TypeEntity>(typeMapped);
            var result = collection.FindOneAndUpdate(filter, update);
            return result != null ? true : false;
        }
    }
}
