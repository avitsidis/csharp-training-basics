using Xunit;

namespace HelloWorld.Tests.ClassLibraryTests
{
    public class AssemblyVersionTest
    {
        [Fact]
        public void HelloWorldModel_version_is_2_0_0_0()
        {
            var expectedVersion = "2.0.0.0";
            var version = HelloWorldModelContext.ModelAssembly.GetName().Version.ToString();
            Assert.Equal(expectedVersion, version);
        }
    }
}
