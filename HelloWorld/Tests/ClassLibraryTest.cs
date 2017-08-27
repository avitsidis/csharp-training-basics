using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace HelloWorld.Tests
{
    public class ClassLibraryTest
    {
        public class AssemblyReferenceAndPropertiessTest
        {
            const string MODEL_ASSEMBLY_NAME = "HelloWorld.Model";
            private static Assembly ModelAssembly => Assembly.Load(Assembly.GetExecutingAssembly()
                       .GetReferencedAssemblies()
                       .Single(a => a.Name == MODEL_ASSEMBLY_NAME));

            private Type PersonType {
            get {
                    return Assembly.Load(Assembly.GetExecutingAssembly()
                       .GetReferencedAssemblies()
                       .Single(a => a.Name == MODEL_ASSEMBLY_NAME))
                       .DefinedTypes.Single(t => t.FullName == "HelloWorld.Model.Person");
                }
            }
            

            [Fact]
            public void HelloWorld_references_HelloWorld_Model()
            {
                var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(a => a.Name);
                Assert.Contains("HelloWorld.Model", referencedAssemblies);
            }

            [Fact]
            public void HelloWorld_Model_defines_a_Person_class()
            {
                Assert.Contains(ModelAssembly.DefinedTypes, t => t.FullName == "HelloWorld.Model.Person");
            }


            [Fact]
            public void Person_class_defines_LastName_property()
            {
                TypeAssert.TypeHasAPropertyNamed(PersonType,"LastName");
            }

            [Fact]
            public void Person_class_defines_FirstName_property()
            {
                TypeAssert.TypeHasAPropertyNamed(PersonType,"FirstName");
            }

            [Fact]
            public void Person_class_defines_NISS_property()
            {
                TypeAssert.TypeHasAPropertyNamed(PersonType,"NISS");
            }

            [Fact]
            public void Person_NISS_throws_ArgumentException_When_non_digit_characters_are_provided()
            {
                dynamic person = Activator.CreateInstance(PersonType);
                Assert.Throws<ArgumentException>(() => person.NISS = "a");
            }

            [Fact]
            public void Person_NISS_is_changed_when_digit_characters_are_provided()
            {
                string validNISS = "86031212312";
                dynamic person = Activator.CreateInstance(PersonType);
                person.NISS = validNISS;
                Assert.Equal(validNISS, person.NISS);
            }
        }
    }
}
