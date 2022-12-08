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

        /// <summary>
        /// Runs the application by first initializing the repositories by loading the data from the .txt files.
        /// Then calls the LoginMenu() which starts the user interaction.
        /// </summary>
        static void RunApp()
        {
            LeaderRepo leaderRepo = new LeaderRepo();
            leaderRepo.InitializeRepository();
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.InitializeRepository();
            Menu menu = new Menu();
            menu.LoginMenu();
        }
    }
}