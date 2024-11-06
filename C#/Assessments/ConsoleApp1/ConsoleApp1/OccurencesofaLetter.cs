using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OccurencesofaLetter
    {
        static void Main()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("Enter a letter to count its occurrences:");
            char letterToCount = Console.ReadLine()[0]; 

            int count = CountOccurrences(input, letterToCount);

            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the given string.");
            Console.Read();
        }

        static int CountOccurrences(string str, char letter)
        {
            int count = 0;

            char lowerLetter = char.ToLower(letter);

            foreach (char c in str)
            {
                if (char.ToLower(c) == lowerLetter) 
                {
                    count++;
                }
            }
            return count;
        }
    }
}
