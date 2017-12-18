using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SantaClausData.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SantaClausData.Controllers
{
    public class ToysController : ApiController
    {
        // GET: api/Toys
        public IEnumerable<Toy> Get()
        {
            MongoClient client = new MongoClient(new MongoUrl("mongodb://simone:simone@ds044787.mlab.com:44787/santa_claus_data"));
            IMongoDatabase db = client.GetDatabase("santa_claus_data");
            IMongoCollection<Toy> toys = db.GetCollection<Toy>("toys");
            var toysList = toys.Find(new BsonDocument()).ToList();
            return toysList;
        }

        // GET: api/Toys/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Toys
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Toys/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Toys/5
        public void Delete(int id)
        {
        }
    }
}
