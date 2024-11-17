using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }

        public override string ToString()
        {
            return $"ID: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}";
        }
    }
    class Program3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            string continueInput;

            do
            {
                Console.WriteLine("Enter ID:");
                int empId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                string empName = Console.ReadLine();

                Console.WriteLine("Enter City:");
                string empCity = Console.ReadLine();

                Console.WriteLine("Enter Salary:");
                decimal empSalary = decimal.Parse(Console.ReadLine());

                Employee employee = new Employee
                {
                    EmpId = empId,
                    EmpName = empName,
                    EmpCity = empCity,
                    EmpSalary = empSalary
                };

                employees.Add(employee);

                Console.WriteLine("Do you want to add another employee? (y/n)");
                continueInput = Console.ReadLine().ToLower(); 

            } while (continueInput == "y");

            Console.WriteLine("\nEmployees Data:");
            AllEmployees(employees);

            Console.WriteLine("\nEmployees with salary more than 45000:");
            EmployeesWithHighSalary(employees, 45000);

            Console.WriteLine("\nEmployees from Bangalore:");
            EmployeesFromBangalore(employees);

            Console.WriteLine("\nEmployees sorted by Name:");
            EmployeesSortedByName(employees);

            Console.Read();
        }

        static void AllEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        static void EmployeesWithHighSalary(List<Employee> employees, decimal Threshold)
        {
            var highSalary = employees.Where(e => e.EmpSalary > Threshold);
            foreach (var employee in highSalary)
            {
                Console.WriteLine(employee);
            }
        }

        static void EmployeesFromBangalore(List<Employee> employees)
        {
            var bangaloreEmployees = employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
            foreach (var employee in bangaloreEmployees)
            {
                Console.WriteLine(employee);
            }
        }

        static void EmployeesSortedByName(List<Employee> employees)
        {
            var sorted = employees.OrderBy(e => e.EmpName);
            foreach (var employee in sorted)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
