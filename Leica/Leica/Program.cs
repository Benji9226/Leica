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
            //Hardcoded
                LeaderRepo repo = new LeaderRepo();
                //repo.Add("Benjamin", "benjamin@gmail.com", 0);
                //repo.Add("Vuong", "vuong@gmail.com", 0);
                if (!File.Exists("Leaders.txt"))
                {
                    repo.AddLeadersToFile(repo.GetAll());
                }
            //Hardcoded end

            Menu menu = new Menu();
            menu.MainMenu();

            Console.ReadLine();
        }
    }
}