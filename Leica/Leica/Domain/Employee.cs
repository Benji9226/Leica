using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class Employee
    {
        CheckList checkList = new CheckList();

        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public Employee(string name, string email, int phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void ChangeCheckList(int checkListInput)
        {
            if (checkListInput == 1) { checkList.Q1 = !checkList.Q1; }
            if (checkListInput == 2) { checkList.Q2 = !checkList.Q2; }
            if (checkListInput == 3) { checkList.Q3 = !checkList.Q3; }
            if (checkListInput == 4) { checkList.Q4 = !checkList.Q4; }
            if (checkListInput == 5) { checkList.Q5 = !checkList.Q5; }
            if (checkListInput == 6) { checkList.Q6 = !checkList.Q6; }
        }

        public override string ToString()
        {
            return Name + ";" + Email + ";" + PhoneNumber;
        }
    }
}
