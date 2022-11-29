using Leica.Application;
using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.UI
{
    public class Menu
    {
        Controller controller = new Controller();

        public void MainMenu()
        {
            Console.WriteLine("Leica menu");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. exit");

            if(controller.Login())
            {
                HRMenu();
            }
        }

        public void HRMenu()
        {
            Console.Clear();
            Console.WriteLine("LIST OF ONBOARDEES:");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");

            controller.EmployeeList();

            controller.EmployeeChoice();

        }
    }
}
