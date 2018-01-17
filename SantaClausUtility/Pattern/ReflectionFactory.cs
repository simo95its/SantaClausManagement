using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Pattern
{
    public abstract class ReflectionFactory<TypeFactory, TypeProduct> : 
        Singleton<TypeFactory>, 
        IFactoryMethod<TypeProduct>
        where TypeFactory : ReflectionFactory<TypeFactory, TypeProduct>
        where TypeProduct : IFactoryProduct, new()
    {
        private Lazy<List<Type>> _types { get; set; }

        //private Lazy<List<string>> _paths { get; set; }

        private Lazy<List<Assembly>> _dlls { get; set; }

        private Lazy<List<TypeProduct>> _productsType { get; set; }

        public void SearchAssembliesForFullyQualifiedNames(IEnumerable<Type> types)
        {
            this._types = new Lazy<List<Type>>(() => new List<Type>());
            this._types.Value.AddRange(types);
            //this.ExtractPathsFromAssemblies();
            this.LoadAssemblies();
        }

        /*
        private void ExtractPathsFromAssemblies()
        {
            this._paths = new Lazy<List<string>>(() => new List<string>());
            foreach (var type in this._types.Value)
            {
                string location = Assembly.GetAssembly(type).Location;
                string path = Path.GetDirectoryName(location);
                this._paths.Value.AddRange(Directory.GetFiles(path, "*data*.dll"));
            }
            this._types = null;
        }
        */

        private void LoadAssemblies()
        {
            this._dlls = new Lazy<List<Assembly>>(() => new List<Assembly>());
            this._productsType = new Lazy<List<TypeProduct>>(() => new List<TypeProduct>());
            /*
            foreach (string path in this._paths.Value)
            {
                this._dlls.Value.Add(Assembly.LoadFile(path));
            }
            this._paths = null;
            */

            foreach (var type in this._types.Value)
            {
                this._dlls.Value.Add(Assembly.GetAssembly(type));
            }
        }

        /*
        private void ExtractProductTypes()
        {
            TypeProduct product = new TypeProduct();
            product

                if (this.IsThereAnyProduct)
            {
                this.Products.Add(product.Name, product);
            }
            else
            {
                throw new Exception();
            }
        }
        */

        private bool IsThereAnyProduct(Assembly assembly)
        {
            bool returnValue = false;

            try
            {
                foreach (var type in assembly.GetTypes())
                {
                    returnValue = (type != _connectionType && _connectionType.IsAssignableFrom(type));
                    if (returnValue)
                    {
                        this.ConnectionType = type;
                        break;
                    }
                }
            }
            catch (ReflectionTypeLoadException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return returnValue;
        }

        public abstract TypeProduct FactoryMethod(string typeName);
    }
}
