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

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");

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
                            HRMenu();
                            break;
                        }

                        Console.WriteLine("Wrong email or password, try again:");
                        Console.ReadLine();
                    }
                    break;

                case 2:
                    Console.WriteLine("Have a good day! :-) (press enter to shut down)");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        public void HRMenu()
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
        /// Helping method
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
                currentEmployee.Checklist();
                userInput = int.Parse(Console.ReadLine());
                if (userInput != 0)
                {
                    currentEmployee.ChangeChecklist(userInput);
                }
            }
        }

        /// <summary>
        /// Helping method
        /// </summary>
        public void printOnboadees()
        {
            Console.Clear();
            Console.WriteLine("LIST OF ONBOARDEES");
            Console.WriteLine("INPUT NR. TO SELECT EMPLOYEE");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. " + employeeRepo.GetAll().ElementAt(0).Name + " -   Software Department     -   " + employeeRepo.GetAll().ElementAt(0).Email);
            Console.WriteLine("2. " + employeeRepo.GetAll().ElementAt(1).Name + " -   Software Department     -   " + employeeRepo.GetAll().ElementAt(1).Email);
        }
   
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
