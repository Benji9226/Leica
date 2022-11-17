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
                Leader leader1 = new Leader("Benjamin", "benjamin@gmail.com", 0);
                Leader leader2 = new Leader("Vuong", "vuong@gmail.com", 1);
                repo.AddLeader(leader1);
                repo.AddLeader(leader2);
            //Hardcoded end

            Menu menu = new Menu();
            menu.MainMenu();

            Console.ReadLine();
        }
    }
}