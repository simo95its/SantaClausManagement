using MongoDB.Bson;
using SantaClausManagement.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SantaClausManagement.Models
{
    public class IndexViewModel
    {
        public List<dynamic> Toys { get; set; }

        public List<dynamic> Orders { get; set; }

        public Status OrderStatus { get; set; }

        public IndexViewModel(bool isAdmin, IEnumerable<Toy> toys, IEnumerable<Order> orders)
        {
            Toys = new List<dynamic>();
            Orders = new List<dynamic>();

            foreach (var toy in toys)
            {
                dynamic obj = new ExpandoObject();
                obj.Name = toy.Name;
                obj.Cost = toy.Cost;
                obj.Amount = toy.Amount;
                Toys.Add(obj);
            }
            foreach (var order in orders)
            {
                dynamic obj = new ExpandoObject();
                obj.Id = order.Id;
                obj.Kid = order.Kid;
                obj.Status = order.Status;
                obj.RequestDate = order.RequestDate;

                if (isAdmin)
                {
                    double? totalPrice = 0;

                    foreach (var toy in order.Toys)
                    {
                        totalPrice += toy.Cost;
                    }
                    
                    obj.TotalPrice = totalPrice;
                    
                }
                Orders.Add(obj);
            }
        }
    }
}