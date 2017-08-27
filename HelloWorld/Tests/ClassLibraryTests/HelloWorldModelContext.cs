using System;
using System.Linq;
using System.Reflection;

namespace HelloWorld.Tests.ClassLibraryTests
{
    public static class HelloWorldModelContext
    {
        public static string AssemblyName => "HelloWorld.Model";
        public static Assembly ModelAssembly => Assembly.Load(Assembly.GetExecutingAssembly()
                   .GetReferencedAssemblies()
                   .Single(a => a.Name == AssemblyName));

        public static Type PersonType
        {
            get
            {
                var personTypeFullName = $"{AssemblyName}.Person";
                return Assembly.Load(Assembly.GetExecutingAssembly()
                   .GetReferencedAssemblies()
                   .Single(a => a.Name == AssemblyName))
                   .DefinedTypes.Single(t => t.FullName == personTypeFullName);
            }
        }
    }
}
