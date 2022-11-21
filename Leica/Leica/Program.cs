using Leica.Application;
using Leica.Domain;
using Leica.UI;
using System.Net.NetworkInformation;

namespace Leica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Lav en RunApp() igen.
            Controller controller = new Controller();
            controller.InitializeController();

            controller.CreateLeader("Benjamin", "benjamin@gmail.com", 0);
            controller.CreateLeader("Vuong", "vuong@gmail.com", 1);

            controller.CreateEmployee("Philip", "email@", 40509288);
            controller.CreateEmployee("Oliver", "email@", 40509288);

            controller.PrintMenu();

            //controller.PrintEmployees();
            Console.ReadLine();
        }
    }
}