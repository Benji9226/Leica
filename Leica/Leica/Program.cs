using Leica.Application;
using Leica.Domain;
using Leica.UI;
using System.Net.NetworkInformation;

namespace Leica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunApp();
        }

        static void RunApp()
        {
            //Hardcoded FILE MUST EXISTS WITH ATLEAST 1 USER
                LeaderRepo leaderRepo = new LeaderRepo();
                leaderRepo.InitializeRepository();

            EmployeeRepo employeeRepo = new EmployeeRepo();
            
                employeeRepo.InitializeRepository();
            //employeeRepo.Add("Vuongvuongsen", "vuong@gmail.com", 555);
           // employeeRepo.AddEmployeesToFile();
            //Hardcoded end


            Menu menu = new Menu();
            menu.MainMenu();

            Console.ReadLine();
        }
    }
}