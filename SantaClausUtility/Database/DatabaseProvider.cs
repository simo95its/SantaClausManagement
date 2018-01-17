using SantaClausUtility.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Database
{
    public class DatabaseProvider : IFactoryProduct
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public Assembly Assembly { get; private set; }
        public Type GenericProductType { get; private set; }
        public Type ProductType { get; private set; }
        public bool IsProduct { get; private set; }

        public DatabaseProvider()
        {
            this.GenericProductType = typeof(IDatabaseConnection);
        }

        public DatabaseProvider SetProperties(Assembly assembly)
        {
            this.Assembly = assembly;

            this.Name = Assembly.ManifestModule.Name.Replace(".dll", "");

            this.FullName = Assembly.FullName;

            try
            {
                this.IsProduct = IsThereAnyProduct(assembly);
            }
            catch (ReflectionTypeLoadException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return this;
        }

        protected bool IsThereAnyProduct(Assembly assembly)
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
            catch(ReflectionTypeLoadException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return returnValue;
        }

        public IDatabaseConnection CreateConnection()
        {
            IDatabaseConnection returnValue;

            try
            {
                returnValue = (IDatabaseConnection)Activator.CreateInstance(this.ConnectionType);

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Unable to initialize connection for " + this.Name);
            }
            catch(Exception)
            {
                throw new Exception();
            }

            return returnValue;
        }
    }
}
