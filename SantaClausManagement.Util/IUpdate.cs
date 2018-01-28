using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public interface IUpdate
    {
        bool Update<TypeEntity, TypeProperty>(string id, string propertyName, TypeProperty value);
    }
}
