using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ExchangeCharacters
    {
        static void Main()
        {
            Console.WriteLine("Enter strings :");

            while (true)
            {
                string input = Console.ReadLine();

                string result = Exchange(input);
                Console.WriteLine("Result: " + result);
            }
        }

        static string Exchange(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return input;
            }

            char first = input[0];
            char last = input[input.Length - 1];

            if (input.Length == 2)
            {
                return last.ToString() + first.ToString();
            }

            string middle = input.Substring(1, input.Length - 2);
            return last + middle + first;
        }
    }
}
