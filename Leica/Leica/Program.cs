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
            //Hardcoded Leader
                LeaderRepo repo = new LeaderRepo();
                Leader leader1 = new Leader("Benjamin", "benjamin@gmail.com", 0);
                Leader leader2 = new Leader("Vuong", "vuong@gmail.com", 1);
                repo.AddLeader(leader1);
                repo.AddLeader(leader2);
            //Hardcoded end

            //Hardcoded Employee
            EmployeeRepo repoEm = new EmployeeRepo();
            Employee Employee1 = new Employee("Benjamin", "benjamin@gmail.com", 42445203);
            Employee Employee2 = new Employee("Vuong", "vuong@gmail.com", 99998888);
            repoEm.AddEmployee(Employee1);
            repoEm.AddEmployee(Employee2);
            //Hardcoded end

            Menu menu = new Menu();
            menu.MainMenu();

            Console.ReadLine();
        }
    }
}