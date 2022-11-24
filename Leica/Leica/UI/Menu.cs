using Leica.Application;
using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.UI
{
    public class Menu
    {
        Controller controller = new Controller();

        public void MainMenu()
        {
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");

            if(controller.Login())
            {
                HRMenu();
            }
        }

        public void HRMenu()
        {
            Console.Clear();
            Console.WriteLine("HELLO {insert name here} HERE IS A LIST OF ONBOARDEES:");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1. P NAGEL       -   Software Department     -   philip.v.nagel@gmail.com");
            Console.WriteLine("2. B EFTERNAVN   -   Software Department     -   benjamin@gmail.com");
            Console.WriteLine("3. V EFTERNAVN   -   Software Department     -   vuong@gmail.com");
            Console.WriteLine("4. V EFTERNAVN   -   Reception Department    -   valdemar@gmail.com");
            Console.WriteLine("5. C EFTERNAVN   -   Reception Department    -   christoffer@gmail.com");
        }

        public void ShowChecklist()
        {
            Console.Clear();
            Console.WriteLine("Activities: ");
            Console.WriteLine();
            Console.WriteLine("1. [DONE] Base data created") ;
            Console.WriteLine("2. [NOT DONE] HM registered of IT equipment");
            Console.WriteLine("3. [DONE] Order is created");
            Console.WriteLine("4. [NOT DONE] Onboarding Plan (Miro) finalised");
            Console.WriteLine("5. [DONE] Data to mail template");
            Console.WriteLine("6. [Done] Sent intro email");
            Console.WriteLine("Choose an activity to change status: ");
            int.TryParse(Console.ReadLine(), out int choice);
        }
    }
}
