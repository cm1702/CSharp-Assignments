using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Employee
    {
        public int Empid { get; private set; }
        public string Empname { get; private set; }
        public float Salary { get; private set; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Employee ID: {Empid}");
            Console.WriteLine($"Employee Name: {Empname}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; private set; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages)
            : base(empid, empname, salary) 
        {
            Wages = wages;
        }

        public void DisplayParttimeInfo()
        {
            DisplayInfo(); 
            Console.WriteLine($"Wages: {Wages}");
        }
    }

    class Program5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee ID:");
            int empid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Name:");
            string empname = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            float salary = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Wages:");
            float wages = float.Parse(Console.ReadLine());

            ParttimeEmployee parttimeEmp = new ParttimeEmployee(empid, empname, salary, wages);

            Console.WriteLine("\nPart-Time Employee Information:");
            parttimeEmp.DisplayParttimeInfo();
            Console.Read();
        }
    }
}
