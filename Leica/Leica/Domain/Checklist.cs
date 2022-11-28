using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Domain
{
    public class CheckList
    {
        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }
        public bool Q4 { get; set; }
        public bool Q5 { get; set; }
        public bool Q6 { get; set; }

        public CheckList()
        {
            Q1 = false;
            Q2 = false;
            Q3 = false;
            Q4 = false;
            Q5 = false;
            Q6 = false;
        }

        public void Show()
        {
            Console.WriteLine($"1: Base data created? {Q1}");
            Console.WriteLine($"2: HM registered of IT equipment? {Q2}");
            Console.WriteLine($"3: Order is created? {Q3}");
            Console.WriteLine($"4: Onboarding Plan (Miro) finalised? {Q4}");
            Console.WriteLine($"5: Data to mail template? {Q5}");
            Console.WriteLine($"6: Sent intro email? {Q6}");
        }
    }
}
