using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public class Database
    {
        private Dictionary<string, IQueryable> _queryableObject;

        //object TypeConnection { get; }

        public Database()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var query = from type in assembly.GetTypes()
                        where type != typeof(IDataConnection)
                        && typeof(IDataConnection).IsAssignableFrom(type)
                        select type;

            var result = query.SingleOrDefault();
            /*
            if (result != null)
            {
                TypeConnection = result;
            }
            */
            var dataConnection = Activator.CreateInstance(result) as IDataConnection;
            
            var mapper = dataConnection.Map();
            _queryableObject = dataConnection.GetQueryableObjectsList(mapper);
        }

        public User GetUser(string email, string hash)
        {
            var query = from user in _queryableObject["users"] 
                        as IQueryable<User>
                        where user.Email == email && user.Password == hash
                        select user;
            
            return query.SingleOrDefault();
        }

        public List<Toy> GetAllToys()
        {
            var queryToys = from toy in _queryableObject["toys"] 
                            as IQueryable<Toy>
                            select toy;

            List<Toy> toysList = queryToys.ToList();

            return toysList;
        }

        public List<Order> GetAllOrderSortedByOldestOne()
        {
            var queryOrders = from order in _queryableObject["orders"] 
                              as IQueryable<Order>
                              orderby order.RequestDate descending
                              select order;

            List<Order> ordersList = queryOrders.ToList();
            return ordersList;
        }

        public List<Order> GetAllOrdersJoinedWithToyDetails()
        {
            var ordersList = GetAllOrderSortedByOldestOne();
            var toysList = GetAllToys();
            foreach (var order in ordersList)
            {
                var query = from toy in order.Toys
                            join toyDetails in toysList
                            on toy.Name equals toyDetails.Name
                            orderby order.RequestDate descending
                            select toyDetails;

                order.Toys = query.ToList();
            }
            return ordersList;
        }

        public Order GetOrder(string id)
        {
            var query = from order in _queryableObject["orders"] as IQueryable<Order>
                        where order.Id == id 
                        select order;

            return query.SingleOrDefault();
        }
    }
}
