using Leica.Application;
using Leica.Domain;
using System.Net.NetworkInformation;

namespace Leica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunApp();
            Console.ReadLine();
        }

        static void RunApp()
        {
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");
            MenuChoice();
            

        }

        static void MenuChoice()
        {
            int.TryParse(Console.ReadLine(), out int choice);
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Email: ");
                    string emailInput = Console.ReadLine();
                    Console.Write("\nEnter Password: ");
                    int.TryParse(Console.ReadLine(), out int passwordInput);
                    LoginCheck(emailInput, passwordInput);
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

        static void LoginCheck(string email, int password)
        {
            using(StreamReader sr = new StreamReader("Leaders.txt"))
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
                        Console.WriteLine("Hurra! THIS WAS AN ACTUAL ACCOUNT");

                        break;
                    }
                }

                if (controlEmail != email || controlPassword != password)
                {
                    Console.WriteLine("Email or password are incorrect");
                }
            }
           
        }
        
    }
}