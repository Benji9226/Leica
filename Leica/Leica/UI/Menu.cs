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

        public void LoginMenu()
        {
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");

            if (controller.Login())
            {
                int menu = -1;
                while (menu != 0)
                {
                    MainMenu();
                    int.TryParse(Console.ReadLine(), out int menuChoice);

                    while (menuChoice != 0)
                    {
                        if (menuChoice == 1)
                        {
                            HRMenu();
                        }

                        else if (menuChoice == 2)
                        {
                            Console.Write("Employee name: ");
                            string name = Console.ReadLine();
                            Console.Write("Employee email: ");
                            string email = Console.ReadLine();
                            Console.Write("Employee phoneNumber: ");
                            int phoneNumber = int.Parse(Console.ReadLine());
                            controller.CreateEmployee(name, email, phoneNumber);
                        }

                        menuChoice = 0;

                        //switch (menuChoice)
                        //{
                        //    case 1:
                        //        {
                        //            HRMenu();

                        //        }
                        //        break;
                        //    case 2:
                        //        Console.Write("Employee name: ");
                        //        string name = Console.ReadLine();
                        //        Console.Write("Employee email: ");
                        //        string email = Console.ReadLine();
                        //        Console.Write("Employee phoneNumber: ");
                        //        int phoneNumber = int.Parse(Console.ReadLine());
                        //        controller.CreateEmployee(name, email, phoneNumber);
                        //        break;
                        //    default:
                        //        menuChoice = 0;
                        //        break;
                        //}
                    }
                }
            }

            void HRMenu()
            {
                    Console.Clear();
                    Console.WriteLine("LIST OF ONBOARDEES:");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------");

               
                    controller.EmployeeList();
                controller.EmployeeChoice();
            }

            void MainMenu()
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("");
                Console.WriteLine("1. Show employee list.");
                Console.WriteLine("2. Create new employee.");
                Console.WriteLine("0. EXIT");
                Console.Write("Choose an option: ");
            }
        }
    }
}
