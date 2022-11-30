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

        public bool Login()
        {
            int.TryParse(Console.ReadLine(), out int choice);
            Console.Clear();
            switch (choice)
            {
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
                case 2:
                    Environment.Exit(0);
                    break;
            }
            return false;
        }
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
        public void EmployeeList()
        {
            List<Employee> employeeList = employeeRepo.GetAll();
            int employeeCount = 1;

            foreach (Employee e in employeeList)
            {
                Console.WriteLine($"{employeeCount}: {e.Name}   ~   {e.Email}");
                employeeCount++;
            }
        }
        public void EmployeeChoice(int employeeChoice)
        {
            Console.Clear();
            List<Checklist> checklistList = checklistRepo.GetAll();

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

        public void CreateEmployee(string name, string email, int phoneNumber)
        {
            employeeRepo.Add(name, email, phoneNumber);
            employeeRepo.AddEmployeesToFile();
        }

        public void CreateChecklist()
        {
            checklistRepo.Add();
            checklistRepo.AddChecklistsToFile();
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
