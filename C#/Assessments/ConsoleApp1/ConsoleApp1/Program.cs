using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.Write("Enter the position of the character to remove (0 to {0}): ", input.Length - 1);
            int position;

            while (!int.TryParse(Console.ReadLine(), out position) || position < 0 || position >= input.Length)
            {
                Console.Write("Invalid position. Please enter a valid position (0 to {0}): ", input.Length - 1);
            }

            string result = RemoveCharacterAtPosition(input, position);
            Console.WriteLine("Resulting string: " + result);
        }

        static string RemoveCharacterAtPosition(string input, int position)
        {
            return input.Remove(position, 1);
        }       
    }
    
}
