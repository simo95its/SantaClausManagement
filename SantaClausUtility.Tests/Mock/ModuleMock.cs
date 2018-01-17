using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausUtility.Tests.Mock
{
    internal class ModuleMock : Module
    {
        public override string Name {
            get
            {
                return "Name";
            }
        }
    }
}
