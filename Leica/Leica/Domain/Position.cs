using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class Position
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public int Password { get; set; }

        public Position(string name, string email, int number, int password)
        {
            Name = name;
            Email = email;
            Number = number;
            Password = password;
        }
    }
}

