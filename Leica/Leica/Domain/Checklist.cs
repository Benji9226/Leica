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
        // Properties of each question of the checklist
        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }
        public bool Q4 { get; set; }
        public bool Q5 { get; set; }
        public bool Q6 { get; set; }

        // string declarations for setting questions to text.
        string changeChecklistText1 = "";
        string changeChecklistText2 = "";
        string changeChecklistText3 = "";
        string changeChecklistText4 = "";
        string changeChecklistText5 = "";
        string changeChecklistText6 = "";

        /// <summary>
        /// Constructor, all questions start with bool value false, when checklist is created.
        /// </summary>
        public Checklist()
        {
            Q1 = false;
            Q2 = false;
            Q3 = false;
            Q4 = false;
            Q5 = false;
            Q6 = false;
        }

        /// <summary>
        /// Prints the given checklist to console.
        /// </summary>
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

        /// <summary>
        /// If question is selected, negates the bool value of the question and sets it.
        /// True becomes false, vise versa.
        /// </summary>
        /// <param name="checkListInput"></param>
        public void ChangeCheckList(int checkListInput)
        {
            if (checkListInput == 1) { Q1 = !Q1; }
            if (checkListInput == 2) { Q2 = !Q2; }
            if (checkListInput == 3) { Q3 = !Q3; }
            if (checkListInput == 4) { Q4 = !Q4; }
            if (checkListInput == 5) { Q5 = !Q5; }
            if (checkListInput == 6) { Q6 = !Q6; }
        }

        /// <summary>
        /// Method which converts bool value to a text format "DONE" and "NOT DONE" for better user understanding.
        /// </summary>
        public void ChangeCheckListText()
        {
            if (Q1 == true) { changeChecklistText1 = "DONE"; } else { changeChecklistText1 = "NOT DONE"; }
            if (Q2 == true) { changeChecklistText2 = "DONE"; } else { changeChecklistText2 = "NOT DONE"; }
            if (Q3 == true) { changeChecklistText3 = "DONE"; } else { changeChecklistText3 = "NOT DONE"; }
            if (Q4 == true) { changeChecklistText4 = "DONE"; } else { changeChecklistText4 = "NOT DONE"; }
            if (Q5 == true) { changeChecklistText5 = "DONE"; } else { changeChecklistText5 = "NOT DONE"; }
            if (Q6 == true) { changeChecklistText6 = "DONE"; } else { changeChecklistText6 = "NOT DONE"; }
        }

        /// <summary>
        /// ToString method that returns the questions for given checklist as a string.
        /// Used for writing the checklist to a file.
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            return $"{Q1};{Q2};{Q3};{Q4};{Q5};{Q6}";
        }
    }
}
