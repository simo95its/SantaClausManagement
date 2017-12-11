using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public interface ICRUD<TypeElement, TypeId>
    {
        TypeElement Index();
        bool Create(TypeElement element);
        TypeElement Read(TypeId id);
        bool Update(TypeElement element);
        bool Delete(TypeId id);
    }
}
