using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility.Pattern
{
    public interface IFactoryMethod<T>
    {
        T FactoryMethod();
    }
}
