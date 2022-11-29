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
    internal class Controller
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();

        public bool Login()
        {
            Menu menu = new Menu();

            int.TryParse(Console.ReadLine(), out int choice);
            Console.Clear();
            switch (choice)
            {
                case 1:
                    bool login = false;
                    while (login == false)
                    {
                        Console.Write("Enter Email: ");
                        string emailInput = Console.ReadLine();
                        Console.Write("\nEnter Password: ");
                        int.TryParse(Console.ReadLine(), out int passwordInput);
                        login = LoginCheck(emailInput, passwordInput);

                        if (login)
                        {
                            return true;
                        }

                        Console.WriteLine("Wrong email or password, try again:");
                        Console.ReadLine();
                        Console.Clear();
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

            foreach(Employee e in employeeList)
            {
                Console.WriteLine($"{employeeCount}:  {e.Name}   ~   {e.Email}");
                employeeCount++;
            }
        }
        public void EmployeeChoice()
        {
            bool systemCheck = true;
            int.TryParse(Console.ReadLine(), out int employeeChoice);
            Console.Clear();

            CheckList checkList = new CheckList();

            List<Employee> employeeList = employeeRepo.GetAll();
            Employee employee = employeeList.ElementAt(--employeeChoice);

            checkList.Show();
            while(systemCheck)
            {
                int.TryParse(Console.ReadLine(), out int input);
                checkList.ChangeCheckList(input);
                checkList.Show();
                

                if (input == 0) { systemCheck = false; }

            }
        }
    }
}
