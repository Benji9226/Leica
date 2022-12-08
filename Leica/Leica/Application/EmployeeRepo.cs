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

        /// <summary>
        /// Repository constructor
        /// </summary>
        public EmployeeRepo()
        {
            InitializeRepository();
        }

        /// <summary>
        /// Initilizes the repository from text file 'Employees.txt'.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Employees.txt does not exist.");
            }
        }

        /// <summary>
        /// Adds a new employee to the list based on the parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public void Add(string name, string email, int phoneNumber)
        {
            Employee employee = new Employee(name, email, phoneNumber);
            employeeList.Add(employee);
        }

        /// <summary>
        /// Removes an employee from the list at a given index.
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            employeeList.RemoveAt(index);
        }

        /// <summary>
        /// Returns a list of all employees.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            return employeeList;
        }

        /// <summary>
        /// Updates the text file 'Employees.txt' from the current active repository employeeList when called.
        /// </summary>
        public void UpdateEmployeesFile()
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

