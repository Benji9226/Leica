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
        public List<Employee> employeeList = new List<Employee>();

        public Employee Add(string name, string email, int number)
        {
            Employee result = null;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                Employee tempEmployee = new Employee(name, email, number);
                result = tempEmployee;
                employeeList.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid."));
            return result;
        }

        public List<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Helping method
        /// </summary>
        /// <param name="leaderList"></param>
        public void AddEmployeesToFile(List<Employee> employeeList)
        {
            using (StreamWriter fileWriter = new StreamWriter("Employees.txt"))
            {
                foreach (Employee employee in employeeList)
                {
                    fileWriter.WriteLine(employee.ToString());
                }
            }
        }
    }
}
