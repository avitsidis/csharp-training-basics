using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HelloWorld.Tests.ClassLibraryTests
{
    public class AssemblyReferenceAndPropertiessTest
    {
        [Fact]
        public void HelloWorld_references_HelloWorld_Model()
        {
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(a => a.Name);
            Assert.Contains(HelloWorldModelContext.AssemblyName, referencedAssemblies);
        }

        [Fact]
        public void HelloWorld_Model_defines_a_Person_class()
        {
            Assert.Contains(HelloWorldModelContext.ModelAssembly.DefinedTypes, t => t.FullName == "HelloWorld.Model.Person");
        }


        [Fact]
        public void Person_class_defines_LastName_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.PersonType, "LastName",typeof(string));
        }

        [Fact]
        public void Person_class_defines_FirstName_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.PersonType, "FirstName", typeof(string));
        }

        [Fact]
        public void Person_class_defines_NISS_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.PersonType, "NISS", typeof(string));
        }

        [Fact]
        public void Person_NISS_throws_ArgumentException_When_non_digit_characters_are_provided()
        {
            dynamic person = Activator.CreateInstance(HelloWorldModelContext.PersonType);
            Assert.Throws<ArgumentException>(() => person.NISS = "a");
        }

        [Fact]
        public void Person_NISS_is_changed_when_digit_characters_are_provided()
        {
            string validNISS = "86031212312";
            dynamic person = Activator.CreateInstance(HelloWorldModelContext.PersonType);
            person.NISS = validNISS;
            Assert.Equal(validNISS, person.NISS);
        }
    }
}
