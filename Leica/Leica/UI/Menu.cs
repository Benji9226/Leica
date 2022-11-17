using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.UI
{
    public class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");

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
                            HRMenu();
                            break;
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
        }

        public void HRMenu()
        {
            Console.Clear();
            Console.WriteLine("HELLO {insert name here} LIST OF WORKERS ASSIGNED TO YOU:");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1. P NAGEL - Software Department - philip.v.nagel");
            Console.WriteLine("2. P NAGEL - Software Department - philip.v.nagel");
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
