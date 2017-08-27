using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorld.Tests.ClassLibraryTests
{
    public class InheritanceAndPolymorphismTest
    {
        [Fact]
        public void Person_ToString_Is_Overrided()
        {
            dynamic person = Activator.CreateInstance(HelloWorldModelContext.PersonType);
            person.LastName = "Foo";
            person.FirstName = "Bar";
            person.NISS = "86031200000";
            Assert.Equal($"Bar Foo(86031200000)", person.ToString());
        }

        [Fact]
        public void Consultant_Inherit_From_Person()
        {
            Assert.Equal(HelloWorldModelContext.PersonType, HelloWorldModelContext.ConsultantType.BaseType);
        }

        [Fact]
        public void Consultant_class_defines_Hiredate_property()
        {
            TypeAssert.TypeHasAProperty(HelloWorldModelContext.ConsultantType, "Hiredate", typeof(DateTime));
        }

        [Fact]
        public void Consultant_overrides_ToString()
        {
            var expectedExperience = 5;
            dynamic person = Activator.CreateInstance(HelloWorldModelContext.ConsultantType);
            person.LastName = "Foo";
            person.FirstName = "Bar";
            person.NISS = "86031200000";
            person.Birthdate = DateTime.Today.AddYears(-24);
            person.Hiredate = DateTime.Today.AddYears(-expectedExperience);

            Assert.Equal($"Bar Foo(86031200000) {expectedExperience} years of experience", person.ToString());
        }

        [Fact]
        public void Person_Birthdate_is_virtual()
        {
            TypeAssert.TypePropertyIsVirtual(HelloWorldModelContext.PersonType, "Birthdate");
        }

        [Fact]
        public void Consultant_Birthdate_throws_ArgumentException_when_instance_is_less_than_18()
        {
            dynamic consultant = Activator.CreateInstance(HelloWorldModelContext.ConsultantType);
            Assert.Throws<ArgumentException>(() => consultant.Birthdate = DateTime.Today.AddYears(19));
        }

        [Fact]
        public void Person_Birthdate_does_not_throws_ArgumentException_when_instance_is_less_than_18()
        {
            dynamic person = Activator.CreateInstance(HelloWorldModelContext.PersonType);
            person.Birthdate = DateTime.Today.AddYears(19);
        }
    }
}
