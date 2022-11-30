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

        string changeCheckListText1 = "";
        string changeCheckListText2 = "";
        string changeCheckListText3 = "";
        string changeCheckListText4 = "";
        string changeCheckListText5 = "";
        string changeCheckListText6 = "";


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
            ChangeCheckListText();
            Console.WriteLine($"1: {changeCheckListText1} ~ Base data created? ");
            Console.WriteLine($"2: {changeCheckListText2} ~ HM registered of IT equipment? ");
            Console.WriteLine($"3: {changeCheckListText3} ~ Order is created? ");
            Console.WriteLine($"4: {changeCheckListText4} ~ Onboarding Plan (Miro) finalised? ");
            Console.WriteLine($"5: {changeCheckListText5} ~ Data to mail template? ");
            Console.WriteLine($"6: {changeCheckListText6} ~ Sent intro email? ");
            Console.Write("Enter activity number to change status: ");
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
            if (Q1 == true) { changeCheckListText1 = "DONE"; } else { changeCheckListText1 = "NOT DONE"; }
            if (Q2 == true) { changeCheckListText2 = "DONE"; } else { changeCheckListText2 = "NOT DONE"; }
            if (Q3 == true) { changeCheckListText3 = "DONE"; } else { changeCheckListText3 = "NOT DONE"; }
            if (Q4 == true) { changeCheckListText4 = "DONE"; } else { changeCheckListText4 = "NOT DONE"; }
            if (Q5 == true) { changeCheckListText5 = "DONE"; } else { changeCheckListText5 = "NOT DONE"; }
            if (Q6 == true) { changeCheckListText6 = "DONE"; } else { changeCheckListText6 = "NOT DONE"; }


        }

    }
}
