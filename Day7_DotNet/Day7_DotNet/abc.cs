using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_DotNet
{
    public class Employee : IComparable<Employee>
    {
        public int EmpId { get; set; }
        public string Name { get; set; }

        public Employee(int empId, string name)
        {
            EmpId = empId;
            Name = name;
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1; 
            return this.EmpId.CompareTo(other.EmpId);
        }

        public override string ToString()
        {
            return $"EmpId: {EmpId}, Name: {Name}";
        }
    }

    public class EmployeeNameComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null && y == null) return 0; 
            if (x == null) return -1; 
            if (y == null) return 1; 

            return string.Compare(x.Name, y.Name); 
        }
    }

    public class abc
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee(45, "ABC"),
            new Employee(17, "XYZ"),
            new Employee(29, "JKL"),
            new Employee(31, "QWE"),
            new Employee(01, "IOP"),
            new Employee(100, "DFG")
        };

            employees.Sort();

            Console.WriteLine("Sorted by EmpId:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

            employees.Sort(new EmployeeNameComparer());

            Console.WriteLine("Sorted by Name:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
