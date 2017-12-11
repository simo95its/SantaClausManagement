using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private Singleton() {}

        private static Singleton Instance { get; }
    }
}
