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

        public EmployeeRepo()
        {
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            try
            {   
                using (StreamReader sr = new StreamReader("Employees.txt"))
                {
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(';');

                        Employee tempEmployee = new Employee(parts[0], parts[1], int.Parse(parts[2]));
                        employeeList.Add(tempEmployee);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Employee Add(string name, string email, int number)
        {
            Employee result = null;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                result = new Employee(name, email, number);
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
