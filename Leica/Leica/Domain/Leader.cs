using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain 
{
    public class Leader
    {
        // Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Leader(string name, string email, int password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Converts the Leader object to a string based on properties.
        /// </summary>
        /// <returns>Leader as a string</returns>
        public override string ToString()
        {
            return Name + ";" + Email + ";" + Password;
        }
    }
}
