using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public Employee(string name, string email, int phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
