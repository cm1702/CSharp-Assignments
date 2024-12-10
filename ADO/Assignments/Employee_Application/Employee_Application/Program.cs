using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public Employee(int employeeID, string firstName, string lastName, string title, DateTime dob, DateTime doj, string city)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            DOB = dob;
            DOJ = doj;
            City = city;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeID}, Name: {FirstName} {LastName}, Title: {Title}, DOB: {DOB.ToShortDateString()}, DOJ: {DOJ.ToShortDateString()}, City: {City}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai"),
            new Employee(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"),
            new Employee(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "Pune"),
            new Employee(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"),
            new Employee(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"),
            new Employee(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"),
            new Employee(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"),
            new Employee(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"),
            new Employee(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"),
            new Employee(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune"),
        };

            // 1. Display a list of all the employees who have joined before 1/1/2015
            Console.WriteLine("Employees who joined before 1/1/2015:");
            var a = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            foreach (var emp in a)
            {
                emp.DisplayDetails();
            }

            // 2. Display a list of all the employees whose date of birth is after 1/1/1990
            Console.WriteLine("\nEmployees whose DOB is after 1/1/1990:");
            var b = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            foreach (var emp in b)
            {
                emp.DisplayDetails();
            }

            // 3. Display a list of all the employees whose designation is Consultant and Associate
            Console.WriteLine("\nEmployees with designation Consultant or Associate:");
            var c = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            foreach (var emp in c)
            {
                emp.DisplayDetails();
            }

            // 4. Display total number of employees
            Console.WriteLine($"\nTotal number of employees: {empList.Count}");

            // 5. Display total number of employees belonging to “Chennai”
            var d = empList.Count(e => e.City == "Chennai");
            Console.WriteLine($"Total number of employees in Chennai: {d}");

            // 6. Display highest employee id from the list
            var f = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {f}");

            // 7. Display total number of employees who have joined after 1/1/2015
            var g = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Total number of employees who joined after 1/1/2015: {g}");

            // 8. Display total number of employees whose designation is not “Associate”
            var h = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"Total number of employees whose designation is not Associate: {h}");

            // 9. Display total number of employees based on City
            Console.WriteLine("\nTotal number of employees based on City:");
            var i = empList.GroupBy(e => e.City).Select(group => new { City = group.Key, Count = group.Count() });
            foreach (var group in i)
            {
                Console.WriteLine($"City: {group.City}, Count: {group.Count}");
            }

            // 10. Display total number of employees based on city and title
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            var j = empList.GroupBy(e => new { e.City, e.Title }).Select(group => new { City = group.Key.City, Title = group.Key.Title, Count = group.Count() });
            foreach (var group in j)
            {
                Console.WriteLine($"City: {group.City}, Title: {group.Title}, Count: {group.Count}");
            }

            // 11. Display total number of employees who is youngest in the list
            var k = empList.Min(e => e.DOB);
            var l = empList.Where(e => e.DOB == k);
            Console.WriteLine("\nYoungest employee(s):");
            foreach (var emp in l)
            {
                emp.DisplayDetails();
            }

            Console.Read();
        }
    }

}
