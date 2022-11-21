using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leica.Domain
{
    public class Employee
    {
        Checklist checklist = new Checklist();

        public string Name { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }

        public Employee(string name, string email, int number)
        {
            Name = name;
            Email = email;
            Number = number;
        }

        public void PrintChecklist()
        {
            checklist.QuestionOne();
        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + Number;
        }
    }
}
