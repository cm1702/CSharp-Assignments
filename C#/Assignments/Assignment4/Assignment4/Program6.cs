using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
        public interface IStudent
        {
            int StudentId { get; set; }

            string Name { get; set; }

            void ShowDetails();
        }
        public class Dayscholar : IStudent
        {
            public int StudentId { get; set; }

            public string Name { get; set; }

            public Dayscholar(int studentId, string name)
            {

                StudentId = studentId;

                Name = name;

            }

            public void ShowDetails()
            {
                Console.WriteLine($"Dayscholar Student Details:\nStudent ID: {StudentId}\nName: {Name}");
            }

        }

        public class Resident : IStudent
        {
            public int StudentId { get; set; }

            public string Name { get; set; }

            public Resident(int studentId, string name)
            {

                StudentId = studentId;

                Name = name;

            }

            public void ShowDetails()
            {
                Console.WriteLine($"Resident Student Details:\nStudent ID: {StudentId}\nName: {Name}");
            }

        }

        class Program6
        {
            static void Main(string[] args)
            {

                Console.WriteLine("Enter details for a Dayscholar student:");

                Console.Write("Enter Student ID: ");

                int dayScholarId = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");

                string dayScholarName = Console.ReadLine();

                IStudent dayScholar = new Dayscholar(dayScholarId, dayScholarName);

                dayScholar.ShowDetails();

                Console.WriteLine("\nEnter details for a Resident student:");

                Console.Write("Enter Student ID: ");

                int residentId = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");

                string residentName = Console.ReadLine();

                IStudent resident = new Resident(residentId, residentName);

                resident.ShowDetails();

                Console.Read();
            }
        }  
}
