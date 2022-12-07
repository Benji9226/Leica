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
        // This is the login menu
        public void LoginMenu()
        {
            Console.WriteLine("LEICA ONBOARDING SYSTEM");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("0. EXIT");

            if (controller.Login())
            {
                while (true)
                {
                    MainMenu();
                    int.TryParse(Console.ReadLine(), out int menuChoice);

                    switch (menuChoice)
                    {
                        case 1:
                            bool repeat = true;
                            while (repeat)
                            {
                                if (HRMenu() == false)
                                {
                                    repeat = false;
                                }
                            }
                            break;
                        case 2:
                            EmployeeCreationMenu();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Show employee list.");
            Console.WriteLine("2. Create new employee.");
            Console.WriteLine("0. EXIT");
            Console.WriteLine();
            Console.Write("Choose an option: ");
        }

        public bool HRMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("LIST OF ONBOARDEES:");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");
                controller.EmployeeList();
                Console.WriteLine("0: EXIT");
                int selection = int.Parse(Console.ReadLine());
                if (selection > 0)
                {
                    controller.EmployeeChoice(selection - 1);
                }
                else
                    return false;
            }
            return true;
        }

        public void EmployeeCreationMenu()
        {
            Console.Clear();
            Console.Write("EMPLOYEE NAME: ");
            string name = Console.ReadLine();

            Console.Write("EMPLOYEE EMAIL: ");
            string email = Console.ReadLine();

            Console.Write("EMPLOYEE PHONE NUMBER: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            controller.CreateEmployee(name, email, phoneNumber);
            controller.CreateChecklist();
        }
    }
}
