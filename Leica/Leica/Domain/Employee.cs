using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    internal class Employee : Position
    {
        public Employee(string name, string email, int number) : base(name, email, number, 0)
        {
        }
    }
}
