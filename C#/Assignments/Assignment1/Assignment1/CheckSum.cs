using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class CheckSum
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Sum(4, 8));
            Console.WriteLine(Sum(19, 10));
            Console.WriteLine(Sum(88, 88));
        }

        public static int Sum(int a, int b)
        {

            return a == b ? (a + b) * 3 : a + b;
        }
    }
}
