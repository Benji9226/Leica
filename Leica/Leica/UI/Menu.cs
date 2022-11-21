using Leica.Application;
using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Leica.UI
{
    public class Menu
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();

        /// <summary>
        /// Prints the main menu and takes the user to further functionality if login is correct.
        /// </summary>
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("**********************");
                Console.WriteLine("*        LEICA       *");
                Console.WriteLine("* ONBOARDING PROGRAM *");
                Console.WriteLine("*                    *");
                Console.WriteLine("* 1. LOGIN           *");
                Console.WriteLine("* 2. EXIT            *");
                Console.WriteLine("**********************");

                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        bool login = false;
                        while (login == false)
                        {
                            Console.Clear();
                            Console.Write("Enter Email: ");
                            string emailInput = Console.ReadLine();
                            Console.Write("\nEnter Password: ");
                            int.TryParse(Console.ReadLine(), out int passwordInput);
                            login = LoginCheck(emailInput, passwordInput);

                            if (login)
                            {
                                EmployeeListMenu();
                                break;
                            }

                            Console.WriteLine("Wrong email or password, try again:");
                            Console.ReadLine();
                        }
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Prints the list of onboardees and provides functionality for editing the checklist
        /// </summary>
        public void EmployeeListMenu()
        {
            int EmployeeChoice = 1;
            while (EmployeeChoice != 0)
            {
                printOnboadees();
                EmployeeChoice = int.Parse(Console.ReadLine());

                if (EmployeeChoice == 1)
                {
                    EmployeeChecklistEditor(EmployeeChoice);
                }

                if (EmployeeChoice == 2)
                {
                    EmployeeChecklistEditor(EmployeeChoice);
                }
            }
        }

        /// <summary>
        /// Helping method for editing the checklist
        /// </summary>
        /// <param name="EmployeeChoice"></param>
        public void EmployeeChecklistEditor(int EmployeeChoice)
        {
            Console.Clear();
            Employee currentEmployee = employeeRepo.GetAll().ElementAt(EmployeeChoice - 1);
            int userInput = 1;
            while (userInput != 0)
            {
                Console.Clear();
                Console.WriteLine(currentEmployee.Name + "'s ONBOARDING PROCESS, INPUT NR. TO CHANGE STATUS, INPUT 0 TO EXIT EMPLOYEE");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine();
                currentEmployee.Checklist();
                userInput = int.Parse(Console.ReadLine());
                if (userInput != 0)
                {
                    currentEmployee.ChangeChecklist(userInput);
                }
            }
        }

        /// <summary>
        /// Helping method that prints the list of onboardees.
        /// </summary>
        public void printOnboadees()
        {
            Console.Clear();
            Console.WriteLine("LIST OF ONBOARDEES");
            Console.WriteLine("INPUT NR. TO SELECT EMPLOYEE OR 0 TO EXIT");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. " + employeeRepo.GetAll().ElementAt(0).Name + " -   Software Department     -   " + employeeRepo.GetAll().ElementAt(0).Email);
            Console.WriteLine("2. " + employeeRepo.GetAll().ElementAt(1).Name + " -   Software Department     -   " + employeeRepo.GetAll().ElementAt(1).Email);
        }
   
        /// <summary>
        /// Helping method that checks if the login credentials are valid and appart of the "Leaders.txt" file.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>true or false</returns>
        public bool LoginCheck(string email, int password)
        {
            if (File.Exists("Leaders.txt"))
            {
                using (StreamReader sr = new StreamReader("Leaders.txt"))
                {
                    string controlEmail = "";
                    int controlPassword = 0;
                    while (!sr.EndOfStream)
                    {
                        string tempString = sr.ReadLine();
                        string[] tempArray = tempString.Split(';');
                        controlEmail = tempArray[1];
                        controlPassword = int.Parse(tempArray[2]);

                        if (controlEmail == email && password == controlPassword)
                        {
                            return true;
                        }
                    }

                    if (controlEmail != email || controlPassword != password)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
