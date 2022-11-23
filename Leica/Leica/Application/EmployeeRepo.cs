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
                using (StreamReader sr = new StreamReader("Employee.txt"))
                {
                    string line = sr.ReadLine();

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

        public Employee Add(string name, string email, int phoneNumber)
        {
            Employee result = null;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                result = new Employee(name, email, phoneNumber);
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

        public void AddEmployeeToFile(List<Employee> employees)
        {
            using (StreamWriter fileWriter = new StreamWriter("Employee.txt"))
            {
                foreach (Employee employee in employeeList)
                {
                    fileWriter.WriteLine(employees.ToString());
                }
            }
        }
    }

}

