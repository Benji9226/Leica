using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leica.Domain
{
    public class Employee : Position
    {
        public Employee(string name, string email, int number) : base(name, email, number, 0)
        {
        }

        public void Checklist()
        {
            Checklist checklist = new Checklist();
            checklist.show();
        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + Number;
        }
    }
}
