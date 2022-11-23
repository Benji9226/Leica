using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Application
{
    public class EmployeeRepo
    {
        public List<Employee> EmployeeList = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
            AddEmployeesToFile(EmployeeList);
        }

        /// <summary>
        /// Helping method
        /// </summary>
        /// <param name="employeeList"></param>
        public void AddEmployeesToFile(List<Employee> employeeList)
        {
            using (StreamWriter fileWriter = new StreamWriter("Employees.txt"))
            {
                foreach (Employee employees in employeeList)
                {
                    fileWriter.WriteLine(employees.ToString());
                }
            }
        }
    }
}

