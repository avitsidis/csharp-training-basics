using System;
using System.Linq;
using Xunit;

namespace HelloWorld.Tests
{
    public static class TypeAssert
    {
        public static void TypeHasAProperty(Type type, string propertyName, Type propertyType, bool ensureItsReadonly = false)
        {
            Assert.Contains(type.GetProperties(), p => p.Name == propertyName);
            var property = type.GetProperties().Single(p => p.Name == propertyName);
            Assert.Equal(propertyType, property.PropertyType);
            if (ensureItsReadonly)
            {
                Assert.Null(property.SetMethod);
            }
        }

        public static void TypePropertyIsVirtual(Type type, string propertyName)
        {
            Assert.Contains(type.GetProperties(), p => p.Name == propertyName);
            var property = type.GetProperties().Single(p => p.Name == propertyName);
            Assert.True(property.GetAccessors()[0].IsVirtual);
        }


    }
}
