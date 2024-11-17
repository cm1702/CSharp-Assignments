using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelConcessionLibrary;

namespace TravelConcessionApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your Age:");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.WriteLine("Please enter a valid age.");
            }

            TravelConcession concession = new TravelConcession();
            string result = concession.CalculateConcession(age);
            Console.WriteLine($"{name}, {result}");
        }
    }
}
