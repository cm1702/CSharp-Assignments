using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {       
        private int rollNo;
        private string name;
        private string studentClass;
        private string semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                while (true) 
                {
                    if (int.TryParse(Console.ReadLine(), out marks[i]) && marks[i] >= 0)
                    {
                        break; 
                    }
                    Console.Write("Please enter a valid non-negative integer for marks: ");
                }
            }
        }

        public void DisplayResult()
        {
            int totalMarks = 0;
            bool hasFailed = false;

            for (int i = 0; i < marks.Length; i++)
            {
                totalMarks += marks[i];
                if (marks[i] < 35)
                {
                    hasFailed = true; 
                    break;
                }
            }

            double averageMarks = totalMarks / (double)marks.Length;

            Console.WriteLine($"Student: {name}, Roll No: {rollNo}, Class: {studentClass}, Semester: {semester}, Branch: {branch}");
            if (hasFailed || (averageMarks < 50 && !hasFailed))
            {
                Console.WriteLine($"Result: Failed (Average Marks: {averageMarks:F2})");
            }
            else
            {
                Console.WriteLine($"Result: Passed (Average Marks: {averageMarks:F2})");
            }
        }
    }

    class Program3
    {
        static void Main()
        {
            Console.Write("Enter Roll Number: ");
            int rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, studentClass, semester, branch);

            student.GetMarks();
            student.DisplayResult();
        }
    }
}
