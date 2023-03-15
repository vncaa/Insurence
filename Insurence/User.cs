using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurence
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public User(string firstName, string lastName, int age, int phoneNumber)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - vek: {Age}, tel. cislo: {PhoneNumber}";
        }
    }
}
