using HelloWorld.Model;
using System;
using System.Configuration;
using System.Drawing;
using Console = Colorful.Console;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"myparameter={ConfigurationManager.AppSettings["myparameter"]}");
            Person p = new Person{
                NISS="1234567890",
                LastName = "Jackson",
                FirstName = "Jackson",
                Birthdate = new DateTime(1958,8,29)
            };
            Console.WriteLine($"person : {p}",Color.Azure);
        }
    }
}
