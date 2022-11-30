using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leica.Domain
{
    public class Checklist
    {
        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }
        public bool Q4 { get; set; }
        public bool Q5 { get; set; }
        public bool Q6 { get; set; }

        string changeChecklistText1 = "";
        string changeChecklistText2 = "";
        string changeChecklistText3 = "";
        string changeChecklistText4 = "";
        string changeChecklistText5 = "";
        string changeChecklistText6 = "";


        public Checklist(bool q1, bool q2, bool q3, bool q4, bool q5, bool q6)
        {
            Q1 = q1;
            Q2 = q2;
            Q3 = q3;
            Q4 = q4;
            Q5 = q5;
            Q6 = q6;
        }

        public void Show()
        {
            ChangeCheckListText();
            Console.WriteLine($"1: {changeChecklistText1} ~ Base data created? ");
            Console.WriteLine($"2: {changeChecklistText2} ~ HM registered of IT equipment? ");
            Console.WriteLine($"3: {changeChecklistText3} ~ Order is created? ");
            Console.WriteLine($"4: {changeChecklistText4} ~ Onboarding Plan (Miro) finalised? ");
            Console.WriteLine($"5: {changeChecklistText5} ~ Data to mail template? ");
            Console.WriteLine($"6: {changeChecklistText6} ~ Sent intro email? ");
            Console.WriteLine($"0: EXIT");
            Console.Write("\nSELECT ACTIVITY TO CHANGE: ");
        }

        public void ChangeCheckList(int checkListInput)
        {
            if (checkListInput == 1) { Q1 = !Q1; }
            if (checkListInput == 2) { Q2 = !Q2; }
            if (checkListInput == 3) { Q3 = !Q3; }
            if (checkListInput == 4) { Q4 = !Q4; }
            if (checkListInput == 5) { Q5 = !Q5; }
            if (checkListInput == 6) { Q6 = !Q6; }
        }

        public void ChangeCheckListText()
        {
            if (Q1 == true) { changeChecklistText1 = "DONE"; } else { changeChecklistText1 = "NOT DONE"; }
            if (Q2 == true) { changeChecklistText2 = "DONE"; } else { changeChecklistText2 = "NOT DONE"; }
            if (Q3 == true) { changeChecklistText3 = "DONE"; } else { changeChecklistText3 = "NOT DONE"; }
            if (Q4 == true) { changeChecklistText4 = "DONE"; } else { changeChecklistText4 = "NOT DONE"; }
            if (Q5 == true) { changeChecklistText5 = "DONE"; } else { changeChecklistText5 = "NOT DONE"; }
            if (Q6 == true) { changeChecklistText6 = "DONE"; } else { changeChecklistText6 = "NOT DONE"; }
        }
        public override string ToString()
        {
            return $"{Q1};{Q2};{Q3};{Q4};{Q5};{Q6}";
        }

    }
}
