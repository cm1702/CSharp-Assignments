using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class WordsSameorNot
    {
        static void Main()
        {
            Console.Write("Enter the first word: ");
            string first = Console.ReadLine();

            Console.Write("Enter the second word: ");
            string second = Console.ReadLine();

            bool aresame = string.Equals(first, second, StringComparison.OrdinalIgnoreCase);

            if (aresame)
            {
                Console.WriteLine("The two words are the same.");
            }
            else
            {
                Console.WriteLine("The two words are not the same.");
            }
        }
    }
}
