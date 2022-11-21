using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leica.Domain;
using Leica.UI;
using Leica.Application;

namespace Leica.Application
{
    public class Controller
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        LeaderRepo leaderRepo = new LeaderRepo();


        public Controller()
        {
            InitializeController();
        }

        public void InitializeController()
        {
            //Hardcoded
            Leader leader1 = new Leader("Benjamin", "benjamin@gmail.com", 0);
            Leader leader2 = new Leader("Vuong", "vuong@gmail.com", 1);
            leaderRepo.AddLeader(leader1);
            leaderRepo.AddLeader(leader2);
           
            employeeRepo.Add("Philip", "email@email", 40509288);
            employeeRepo.Add("Oliver", "email@email", 40509288);
            //Hardcoded end
        }

        public void PrintEmployees()
        {
            List<Employee> temp = employeeRepo.GetAll();

            foreach (Employee employee in temp)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        public void PrintMenu()
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
