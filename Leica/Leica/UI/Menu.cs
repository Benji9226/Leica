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

        /// <summary>
        /// Login menu to ensure only allowed personel have access to the system.
        /// If the login is a success, the user is presented with the main menu.
        /// </summary>
        public void LoginMenu()
        {
            Console.WriteLine("LEICA ONBOARDING SYSTEM");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("0. EXIT");

            if (controller.Login())
            {
                // Endless loop until user inputs exit code '0'.
                while (true)
                {
                    MainMenu();
                    int.TryParse(Console.ReadLine(), out int menuChoice);

                    switch (menuChoice)
                    {
                        // Shows onboardee list and gives access to their checklists. (Repeatable until exit)
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

                        // Create new employee option.
                        case 2:
                            EmployeeCreationMenu();
                            break;

                        // Deletion of employee option (Repeatable until exit)
                        case 3:
                            repeat = true;
                            while (repeat)
                            {
                                Console.Clear();
                                Console.WriteLine("LIST OF EMPLOYEES:");
                                Console.WriteLine();
                                Console.WriteLine("Nr NAME   ~   EMAIL   ~   PHONE");
                                Console.WriteLine("---------------------------------------------------------");
                                controller.EmployeeList();
                                Console.WriteLine("0: EXIT");

                                int.TryParse(Console.ReadLine(), out int employeeToDelete);
                                if (employeeToDelete != 0)
                                {
                                    controller.DeleteEmployee(employeeToDelete - 1);
                                }
                                else if (employeeToDelete == 0)
                                {
                                    repeat = false;
                                }
                            }
                            break;

                        // Exit program option.
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the Main menu to console.
        /// </summary>
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Show employee list.");
            Console.WriteLine("2. Create new employee.");
            Console.WriteLine("3. Delete employee");
            Console.WriteLine("0. EXIT");
            Console.WriteLine();
            Console.Write("Choose an option: ");
        }

        /// <summary>
        /// Sub menu which prints the list of employees to console, and allows the user to select one 
        /// to retrieve and change their checklist.
        /// </summary>
        /// <returns>true or false</returns>
        public bool HRMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("LIST OF EMPLOYEES:");
                Console.WriteLine();
                Console.WriteLine("Nr NAME   ~   EMAIL   ~   PHONE");
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

        /// <summary>
        /// Prints the EmployeeCreationMenu to console and takes user input to use for creation of 
        /// new employee through the controller.
        /// </summary>
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