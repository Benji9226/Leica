using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class Checklist
    {
        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }

        public Checklist()
        {
            Q1 = false;
            Q2 = false;
            Q3 = false;
        }
        public void ShowEmployeeChecklist()
        {
            Console.WriteLine("1. BASE DATA CREATED: " + Q1);
            Console.WriteLine("2. SOFTWARE INTRODUCTION: " + Q2);
            Console.WriteLine("3. COMMS INTRODUCTION: " + Q3);
        }
    }
}
