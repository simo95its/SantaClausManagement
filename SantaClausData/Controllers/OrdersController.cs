using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SantaClausData.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Web.Http.Cors;

namespace SantaClausData.Controllers
{
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IEnumerable<Order> GetOrders()
        {
            MongoClient client = new MongoClient(new MongoUrl("mongodb://simone:simone@ds044787.mlab.com:44787/santa_claus_data"));
            IMongoDatabase db = client.GetDatabase("santa_claus_data");
            IMongoCollection<Order> orders = db.GetCollection<Order>("orders");
            var ordersList = orders.Find(new BsonDocument()).ToList();
            return ordersList;
        }
        
        // GET: api/Orders/5
        public IHttpActionResult GetOrders(string id)
        {
            ObjectId objectId = new ObjectId(id);
            MongoClient client = new MongoClient(new MongoUrl("mongodb://simone:simone@ds044787.mlab.com:44787/santa_claus_data"));
            IMongoDatabase db = client.GetDatabase("santa_claus_data");
            IMongoCollection<Order> orders = db.GetCollection<Order>("orders");
            /**/
            var filter = Builders<Order>.Filter.Eq("_id", objectId);
            var order = orders.Find(filter).First();
            if (order == null)
            {
                return NotFound();
            }
            /**/
            return Ok(order);
        }

        // POST: api/Orders
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
        }
    }
}
