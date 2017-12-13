using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SantaClausUtility
{
    public interface ICRUD<TypeElement, TypeId>
    {
        bool Create(Func<TypeId, bool> creation, OptionalAttribute element);
        TypeElement Read(Func<TypeId, TypeElement> read, OptionalAttribute id);
        bool Update(Func<TypeId, bool> update, OptionalAttribute element);
        bool Delete(Func<TypeId, bool> deletion, OptionalAttribute element);
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
