using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausUtility.Tests.Mock
{
    internal class AssemblyMock : Assembly
    {
        private string _returnTypeOfGetTypesMethod { get; set; }

        public override Module ManifestModule {
            get
            {
                return new ModuleMock();
            }
        }

        public override string FullName {
            get
            {
                return "FullName";
            }
        }

        public AssemblyMock(string returnTypeOfGetTypesMethod = "true")
        {
            this._returnTypeOfGetTypesMethod = returnTypeOfGetTypesMethod;
        }

        public override Type[] GetTypes()
        {
            switch (this._returnTypeOfGetTypesMethod)
            {
                case "ReflectionTypeLoadException":
                    throw new ReflectionTypeLoadException(null, null);
                case "false":
                    return new Type[] { typeof(AssemblyMock) };
                case "true":
                default:
                    break;
            }
            return new Type[] { typeof(DbConnectionMock) };
        }
    }
}
