using System;
using System.Text.RegularExpressions;

namespace HelloWorld.Model
{
    public class Person
    {
        private string _niss;

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NISS {
            get { return _niss; }
            set {
                if (!Regex.IsMatch(value, "\\d+"))
                    throw new ArgumentException("NISS must contain digits only");
                _niss = value;
            }
        }

        public virtual DateTime Birthdate { get; set; }

        public int Age {
        get {
                var today = DateTime.Today;
                var ydiff = today.Year - Birthdate.Year;
                return Birthdate.AddYears(ydiff) > today ? ydiff - 1 : ydiff; 
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}({NISS})";
        }
    }
}
