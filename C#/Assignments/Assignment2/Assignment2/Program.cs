using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Swapping
    {

        public static void Main(string[] args)
        {

            int a, b, temp;
            Console.Write("\nInput the First Number : ");
            a = int.Parse(Console.ReadLine());
            Console.Write("\nInput the Second Number : ");
            b = int.Parse(Console.ReadLine());

            temp = a;
            a = b;
            b = temp;

            Console.Write("\nAfter Swapping : ");
            Console.Write("\nFirst Number : " + a);
            Console.Write("\nSecond Number : " + b);
            Console.Read();
        }
    }

}
