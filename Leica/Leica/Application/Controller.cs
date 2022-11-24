using Leica.Domain;
using Leica.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Application
{
    internal class Controller
    {
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



        public void EmployeeChoice()
        {
            int.TryParse(Console.ReadLine(), out int EmployeeChoice);

            switch (EmployeeChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}
