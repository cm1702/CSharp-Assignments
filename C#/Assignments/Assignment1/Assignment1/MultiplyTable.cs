using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class MultiplyTable
    {
        public static void Main()
        {
            int i, j;

            Console.Write("\n\n");
            Console.Write("Display the multiplication table:\n");
            Console.Write("\n\n");

            Console.Write("Input the number (Table to be calculated) : ");
            j = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n");

            for (i = 1; i <= 10; i++)
            {
                Console.Write("{0} X {1} = {2} \n", j, i, j * i);
            }
        }
    }
}
