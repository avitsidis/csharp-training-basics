using System;
using Xunit;

namespace HelloWorld.Tests
{
    public static class TypeAssert
    {
        public static void TypeHasAPropertyNamed(Type type, string propertyName)
        {
            Assert.Contains(type.GetProperties(), p => p.Name == propertyName);
        }
    }
}
