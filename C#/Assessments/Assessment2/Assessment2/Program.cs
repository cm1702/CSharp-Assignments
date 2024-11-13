using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public double Grade { get; set; }

        protected Student(string name, string studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed();
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string name, string studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed()
        {
            return Grade > 70.0;
        }
    }

    public class Graduate : Student
    {
        public Graduate(string name, string studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed()
        {
            return Grade > 80.0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of students:");
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"Enter details for student {i + 1}:");
                Console.WriteLine("Type Undergraduate or Graduate:");
                string type = Console.ReadLine();

                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Student ID:");
                string studentId = Console.ReadLine();

                Console.WriteLine("Enter Grade:");
                double grade = double.Parse(Console.ReadLine());

                Student student;

                if (type.Equals("Undergraduate"))
                {
                    student = new Undergraduate(name, studentId, grade);
                }
                else if (type.Equals("Graduate"))
                {
                    student = new Graduate(name, studentId, grade);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Console.WriteLine($"{student.Name} (ID: {student.StudentId}) - Passed: {student.IsPassed()}");
            }
            Console.Read();
        }
    }
}
