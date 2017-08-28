using System;

namespace HelloWorld.Model
{
    public class Consultant : Person
    {
        public DateTime Hiredate { get; set; }

        public override DateTime Birthdate {
            get => base.Birthdate;
            set {
                if (value > DateTime.Today.AddYears(-18))
                    throw new ArgumentException("Consultant must be older than 18 years old");
                base.Birthdate = value;
            }
        }

        public int Experience
        {
            get
            {
                var today = DateTime.Today;
                var ydiff = today.Year - Hiredate.Year;
                return Hiredate.AddYears(ydiff) > today ? ydiff - 1 : ydiff;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" {Experience} years of experience";
        }
    }
}
