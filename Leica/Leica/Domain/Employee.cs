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
        Checklist checklist = new Checklist();

        public Employee(string name, string email, int number) : base(name, email, number, 0)
        {
        }

        public void Checklist()
        {
            checklist.ShowEmployeeChecklist();
        }

        public void ChangeChecklist(int input)
        {
            if (input == 1) { checklist.Q1 = !checklist.Q1; }
            if (input == 2) { checklist.Q2 = !checklist.Q2; }
            if (input == 3) { checklist.Q3 = !checklist.Q3; }

        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + Number;
        }
    }
}
