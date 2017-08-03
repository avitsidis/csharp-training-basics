using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Xunit;

namespace HelloWorld.Tests
{

    public class ConfigurationTest
    {
        private static readonly string CONFIG_FILE;
        static ConfigurationTest()
        {
            var codeLocation = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            var codeDirectory = Path.GetDirectoryName(codeLocation);
            CONFIG_FILE = Path.Combine(codeDirectory, "HelloWorld.EXE.Config");
        }
        [Fact]
        public void Assembly_Contains_A_Config_File()
        {
            Assert.True(File.Exists(CONFIG_FILE));
        }

        [Fact]
        public void Assembly_Contains_A_Config_File_With_Key_myparameter()
        {
            XDocument xmlDoc = XDocument.Load(CONFIG_FILE);
            var settings = xmlDoc
                .Element("configuration")
                    .Element("appSettings")
                        .Descendants("add");
            var settingsNames = settings.Select(x => x.Attribute("key").Value);
            Assert.Contains("myparameter", settingsNames);
        }

        [Fact]
        public void Config_Key_myparameter_Value_is_foobar()
        {
            XDocument xmlDoc = XDocument.Load(CONFIG_FILE);
            var myparameter = xmlDoc
                .Element("configuration")
                    .Element("appSettings")
                        .Descendants("add").Single(x => x.Attribute("key").Value == "myparameter");
            Assert.Equal("foobar", myparameter.Attribute("value").Value);
        }

        [Fact]
        public void Assembly_System_Configuration_is_loaded()
        {
            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(a=>a.Name);
            Assert.Contains("System.Configuration", referencedAssemblies);
        }
    }
}
