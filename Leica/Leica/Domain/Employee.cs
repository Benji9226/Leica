using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class Employee
    {
        // Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public Employee(string name, string email, int phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Converts the Employee object to a string based on properties.
        /// </summary>
        /// <returns>Employee as a string</returns>
        public override string ToString()
        {
            return Name + ";" + Email + ";" + PhoneNumber;
        }
    }
}