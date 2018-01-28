using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public class Database
    {
        private Dictionary<string, IQueryable> _queryableObject;

        private IDataConnection _dataConnection;

        public Database()
        {
            _dataConnection = Instantiate_With_Reflection();
            Initialize();
        }

        public Database(Type type)
        {
            _dataConnection = Instantiate_With_Reflection(type);
            Initialize();
        }

        private IDataConnection Instantiate_With_Reflection([Optional] Type type)
        {
            Assembly assembly;
            if (type != null)
            {
                assembly = Assembly.GetAssembly(type);
            }
            else
            {
                assembly = Assembly.GetExecutingAssembly();
            }
            var query = from typeAssembly in assembly.GetTypes()
                        where typeAssembly != typeof(IDataConnection)
                        && typeof(IDataConnection).IsAssignableFrom(typeAssembly)
                        select typeAssembly;
            var result = query.SingleOrDefault();

            return Activator.CreateInstance(result) as IDataConnection;
        }

        private void Initialize()
        {
            var mapper = _dataConnection.Map();
            _queryableObject = _dataConnection.GetQueryableObjectsList();
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

        public Order GetOrderWithToyDetails(string id)
        {
            var order = GetOrder(id);
            var toys = GetAllToys();
            var query = from toy in order.Toys
                        join toyDetails in toys
                        on toy.Name equals toyDetails.Name
                        orderby order.RequestDate descending
                        select toyDetails;
            order.Toys = query.ToList();
            return order;
        }

        public bool SetAmountToy(string id, int? amount)
        {
            string propertyName = typeof(Toy).GetProperty("Amount").Name;
            return _dataConnection.Update<Toy, int?>(id, propertyName, amount);
        }

        public bool SetOrderStatus(string id, Status status)
        {
            string propertyName = typeof(Order).GetProperty("Status").Name;
            return _dataConnection.Update<Order, Status>(id, propertyName, status);
        }
    }
}
