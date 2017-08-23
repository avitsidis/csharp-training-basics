using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Xunit;

namespace HelloWorld.Tests
{
    public class NugetTest
    {
        private static readonly string PACKAGES_CONFIG;
        static NugetTest()
        {
            var codeLocation = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            var codeDirectory = Path.GetDirectoryName(codeLocation);
            PACKAGES_CONFIG = Path.Combine(codeDirectory, "packages.config");
        }
        [Fact]
        public void ColorfulConsole_Must_Be_Referenced_And_Used_In_HelloWorld()
        {
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(a => a.Name);
            Assert.Contains("Colorful.Console", referencedAssemblies);
        }

        [Fact]
        public void ColorfulConsole_Must_Be_In_packageConfig_file()
        {
            XDocument xmlDoc = XDocument.Load(PACKAGES_CONFIG);
            var packages = xmlDoc.Element("packages").Descendants("package");
            Assert.Contains(packages, p => p.Attribute("id").Value == "Colorful.Console");
        }
    }
}
