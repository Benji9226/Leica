using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain 
{
    public class Leader
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }

        public Leader(string name, string email, int password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + Password;
        }
    }
}
