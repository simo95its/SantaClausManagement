using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SantaClausUtility
{
    public interface ICRUD<TypeElement, TypeId>
    {
        TypeElement Create(Func<TypeId, TypeElement> creation, TypeId id);
        TypeElement Read(Func<TypeId, TypeElement> read, TypeId id);
        TypeElement Update(Func<TypeId, TypeElement> update, TypeId id);
        TypeElement Delete(Func<TypeId, TypeElement> deletion, TypeId id);
    }
    /*
    public interface ICRUD<TypeElement, TypeId>
    {
        TypeElement Index();
        bool Create(TypeElement element);
        TypeElement Read(TypeId id);
        bool Update(TypeElement element);
        bool Delete(TypeId id);
    }*/
}
