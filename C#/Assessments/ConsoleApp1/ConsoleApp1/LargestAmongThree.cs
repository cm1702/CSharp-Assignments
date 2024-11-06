using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LargestAmongThree
    {
        static void Main()
        {
            Console.WriteLine("Enter first integer:");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second integer:");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter third integer:");
            int thirdNumber = Convert.ToInt32(Console.ReadLine());

            int largestNumber = FindLargest(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine("Largest among all three is: " + largestNumber);
            Console.Read();
        }

        static int FindLargest(int a, int b, int c)
        {
            int largest = a; 

            if (b > largest)
            {
                largest = b; 
            }

            if (c > largest)
            {
                largest = c; 
            }

            return largest; 
        }
    }
}
