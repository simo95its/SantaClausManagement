using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public interface IDataConnection : IUpdate
    {
        string Protocol { get; }
        string Username { get; }
        string Password { get; }
        string Server { get; }
        string Port { get; }
        string DataIdentifier { get; }

        object Connection { get; }

        Dictionary<string, IQueryable> GetQueryableObjectsList();

        Dictionary<string, Type> Map();
    }
}
