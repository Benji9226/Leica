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
            // maybe this? : InitializeController();
        }

        public void InitializeController()
        {
            // something perhaps here?
        }

        public void CreateEmployee(string name, string email, int number)
        {
            employeeRepo.Add(name, email, number);
            employeeRepo.AddEmployeesToFile(employeeRepo.GetAll());
        }

        public void CreateLeader(string name, string email, int password)
        {
            leaderRepo.Add(name, email, password);
            leaderRepo.AddLeadersToFile(leaderRepo.GetAll());
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
