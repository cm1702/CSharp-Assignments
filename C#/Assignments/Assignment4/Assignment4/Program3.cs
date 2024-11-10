using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Doctor
    {
        private string regno;
        private string name;
        private double feesCharged;

        public string Regno
        {
            get { return regno; }
            set { regno = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Fees
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Doctor Details:");
            Console.WriteLine($"Registration No: {Regno}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees Charged: {Fees}"); 
        }
    }

    class Program3
    {
        public static void Main(string[] args)
        {
            Doctor doctor = new Doctor();

            Console.Write("Enter Registration No: ");
            doctor.Regno = Console.ReadLine();

            Console.Write("Enter Doctor's Name: ");
            doctor.Name = Console.ReadLine();

            Console.Write("Enter Fees Charged: ");
            doctor.Fees = double.Parse(Console.ReadLine());

            doctor.DisplayDetails();

            Console.Read();
        }
    }
}
