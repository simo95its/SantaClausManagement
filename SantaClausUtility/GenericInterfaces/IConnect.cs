using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public interface IConnect<TypeHostSettings, TypeHostInstance, TypeHostReturn>
    {
        TypeHostReturn Connect(Func<TypeHostSettings, TypeHostInstance> connection);
    }
}
