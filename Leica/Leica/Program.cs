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
            Controller controller = new Controller();
            controller.PrintMenu();
            controller.PrintEmployees();
            Console.ReadLine();
        }
    }
}