using Leica.Domain;
using Leica.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Application
{
    public class Controller
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        ChecklistRepo checklistRepo = new ChecklistRepo();

        /// <summary>
        /// Login method
        /// </summary>
        /// <returns>true or false</returns>
        public bool Login()
        {
            int.TryParse(Console.ReadLine(), out int choice);
            Console.Clear();
            switch (choice)
            {
                // Repeatable login attempts.
                case 1:
                    bool login = false;
                    while (login == false)
                    {
                        Console.Write("ENTER EMAIL: ");
                        string emailInput = Console.ReadLine();
                        Console.Write("ENTER PASSWORD: ");
                        int.TryParse(Console.ReadLine(), out int passwordInput);
                        login = LoginCheck(emailInput, passwordInput);

                        if (login)
                        {
                            return true;
                        }

                        Console.WriteLine("Wrong email or password, try again...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;

                // Exit option
                case 2:
                    Environment.Exit(0);
                    break;
            }
            return false;
        }

        /// <summary>
        /// Helping method that checks if the login exists in the 'Leaders.txt' file.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>true or false</returns>
        public bool LoginCheck(string email, int password)
        {
            if (File.Exists("Leaders.txt"))
            {
                LeaderRepo leaderRepo = new LeaderRepo();
                foreach (Leader leader in leaderRepo.leaderList)
                {
                    if (email.Equals(leader.Email) && password.Equals(leader.Password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Prints each employee in a row with its attributes.
        /// Also keeps count of amount of employees in the system.
        /// </summary>
        public void EmployeeList()
        {
            List<Employee> employeeList = employeeRepo.GetAll();
            int employeeCount = 1;

            foreach (Employee employee in employeeList)
            {
                Console.WriteLine($"{employeeCount}: {employee.Name}   ~   {employee.Email}   ~   {employee.PhoneNumber}");
                employeeCount++;
            }
        }

        /// <summary>
        /// Takes employeeChoice and presents the user with that employees checklist, and then the option
        /// to change the state of a question on that employees checklist.
        /// </summary>
        /// <param name="employeeChoice"></param>
        public void EmployeeChoice(int employeeChoice)
        {
            Console.Clear();
            List<Checklist> checklistList = checklistRepo.GetAll();

            // Repeatable changes to checklist until input is exit code '0'.
            int input;
            do
            {
                Checklist tempChecklist = checklistList.ElementAt(employeeChoice);
                tempChecklist.Show();
                input = int.Parse(Console.ReadLine());
                tempChecklist.ChangeCheckList(input);
                lineChanger(tempChecklist.ToString(), "Checklists.txt", employeeChoice);
                Console.Clear();

            } while (input != 0);

        }

        /// <summary>
        /// Creates an employee from the given parameters.
        /// Does so by using the employeeRepos Add() method followed by 
        /// UpdateEmployeesFile() so that it is writen in the .txt file.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public void CreateEmployee(string name, string email, int phoneNumber)
        {
            employeeRepo.Add(name, email, phoneNumber);
            employeeRepo.UpdateEmployeesFile();
        }

        /// <summary>
        /// Deletes an employee from the system by calling the employeeRepos Remove() and UpdateEmployeesFile() methods
        /// as well as for the checklist at the same index as they are connected.
        /// </summary>
        /// <param name="index"></param>
        public void DeleteEmployee(int index)
        {
            employeeRepo.Remove(index);
            employeeRepo.UpdateEmployeesFile();
            checklistRepo.Remove(index);
            checklistRepo.UpdateChecklistsFile();
        }

        /// <summary>
        /// Creates a checklist, does so by using the checklisRepos Add() method followed by 
        /// UpdateChecklistsFile() so that it is writen in the .txt file.
        /// </summary>
        public void CreateChecklist()
        {
            checklistRepo.Add();
            checklistRepo.UpdateChecklistsFile();
        }

        /// <summary>
        /// Helping method for the EmployeeChoice() method, helps with the conversion of question value changes in the .txt file.
        /// </summary>
        /// <param name="newText"></param>
        /// <param name="fileName"></param>
        /// <param name="line_to_edit"></param>
        private void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
