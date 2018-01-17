using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Pattern
{
    public interface IFactoryProduct<T>
    {
        string Name { get; }
        string FullName { get; }
        Assembly Assembly { get; }
        Type GenericProductType { get; }
        Type ProductType { get; }
        bool IsProduct { get; }

        T SetProperties(Assembly assembly);
        bool IsThereAnyProduct(Assembly assembly);
    }
}
