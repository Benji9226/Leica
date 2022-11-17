using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain 
{
    public class Leader : Position
    {
        public Leader(string name, string email, int password) : base(name, email, 0, password)
        {
            
        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + Password;
        }
    }
}
