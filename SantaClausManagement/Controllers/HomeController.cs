using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaClausManagement.Models;
using MongoDB.Driver;
using SantaClausUtility;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization;
using System.IO;

namespace SantaClausManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            /*
            MongoClient client = new MongoClient(new MongoUrl("mongodb://simone:simone@ds044787.mlab.com:44787/santa_claus_data"));
            IMongoDatabase db = client.GetDatabase("santa_claus_data");
            IMongoCollection<Toy> toys = db.GetCollection<Toy>("toys");
            IMongoCollection<Order> orders = db.GetCollection<Order>("orders");

            var sortOrder = Builders<Order>.Sort.
            var toysList = toys.Find(new BsonDocument()).ToList();
            var ordersList = orders.Find(new BsonDocument()).Sort(sortOrder).ToList();

    */
            //var query = from document in toys.AsQueryable()
            //            select document;
            //foreach (var item in query)
            //{
            //    model.List.Add(new Toy()
            //    {
            //        Name = item.Name,
            //        Cost = item.Cost,
            //        Amount = item.Amount
            //    }
            //    );
            //}
            string uriOrders = "http://localhost:50546/api/orders";
            string uriToys = "http://localhost:50546/api/toys";

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/bson");
                model.Toys = BsonSerializer.Deserialize<List<Toy>>(webClient.DownloadString(uriOrders));
            }

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/bson");
                model.Toys = BsonSerializer.Deserialize<List<Toy>>(webClient.DownloadString(uriToys));
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}