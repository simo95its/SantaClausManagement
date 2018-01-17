using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SantaClausUtility.Pattern
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => Instantiate());

        public static T Instance
        {
            get => _instance.Value;
        }

        private static T Instantiate() => Activator.CreateInstance(typeof(T), true) as T;
    }
}
