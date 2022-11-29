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
            LeaderRepo leaderRepo = new LeaderRepo();
            leaderRepo.InitializeRepository();
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.InitializeRepository();
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}