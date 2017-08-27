using System;
using Xunit;

namespace HelloWorld.Tests.ClassLibraryTests
{
    public class ComputedPropertyTest
    {

        [Fact]
        public void Person_class_defines_BirthDate_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.PersonType, "Birthdate", typeof(DateTime));
        }

        [Fact]
        public void Person_class_defines_a_readonly_Age_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.PersonType, "Age", typeof(int),true);
        }

    }
}
