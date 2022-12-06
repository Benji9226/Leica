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
                if (File.Exists("Employees.txt"))
                {

                    using (StreamReader sr = new StreamReader("Employees.txt"))
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
            }
            catch (IOException)
            {
                throw;
            }
        }

        public void Add(string name, string email, int phoneNumber)
        {
            Employee result = new Employee(name, email, phoneNumber);
            employeeList.Add(result);
        }

        public List<Employee> GetAll()
        {
            return employeeList;
        }

        public void AddEmployeesToFile()
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

