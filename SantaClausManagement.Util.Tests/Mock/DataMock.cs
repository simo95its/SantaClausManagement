using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util.Tests.Mock
{
    public class DataMock
    {
        private string _projectRootPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
        public JArray Users { get; set; }
        public JArray Orders { get; set; }
        public JArray Toys { get; set; }

        public DataMock()
        {
            Users = JArray.Parse(File.ReadAllText(Path.Combine(_projectRootPath, "Json", "users.json")));
            Orders = JArray.Parse(File.ReadAllText(Path.Combine(_projectRootPath, "Json", "orders.json")));
            Toys = JArray.Parse(File.ReadAllText(Path.Combine(_projectRootPath, "Json", "toys.json")));
        }
    }
}
