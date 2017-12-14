using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SantaClausUtility
{
    public class DatabaseEntitiesList :
        ICRUD<SantaClausUtility.IDatabaseEntity, string>
    {
        public List<IDatabaseEntity> Entities { get; private set; }

        IDatabaseEntity ICRUD<IDatabaseEntity, string>.Create(Func<string, IDatabaseEntity> creation, string id)
        {
            IDatabaseEntity entity = creation(id);
            Entities.Add(entity);
            return entity;
        }

        IDatabaseEntity ICRUD<IDatabaseEntity, string>.Delete(Func<string, IDatabaseEntity> deletion, string id)
        {
            IDatabaseEntity entity = deletion(id);
            Entities.Remove(entity);
            return entity;
        }

        IDatabaseEntity ICRUD<IDatabaseEntity, string>.Read(Func<string, IDatabaseEntity> read, string id)
        {
            IDatabaseEntity entity = read(id);
            Entities.Find(element => element.Id == id);
            return entity;
        }

        IDatabaseEntity ICRUD<IDatabaseEntity, string>.Update(Func<string, IDatabaseEntity> update, OptionalAttribute element)
        {
            throw new NotImplementedException();
        }
    }
}
