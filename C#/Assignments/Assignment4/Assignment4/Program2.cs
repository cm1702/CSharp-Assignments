using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Scholarship
    {
        public void Merit(int marks , double fees)
        {
            double scholarshipamount = 0;
            if(marks >= 70 && marks <= 80)
            {
                scholarshipamount = 0.20 * fees;
            }
            if (marks > 80 && marks <= 90)
            {
                scholarshipamount = 0.30 * fees;
            }
            if (marks >90)
            {
                scholarshipamount = 0.50 * fees;
            }
            Console.WriteLine($"Marks : {marks}, Fees : {fees}, Scholarship amount : {scholarshipamount}");
        }
    }
    class Program2
    {
        public static void Main(string[] args)
        {
            Scholarship scholarship = new Scholarship();

            Console.WriteLine("Enter the marks: ");
            int marks = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the fees: ");
            double fees = double.Parse(Console.ReadLine());

            scholarship.Merit(marks, fees);
            Console.Read();
        }
    }
}
