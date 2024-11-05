using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ReverseofString
    {
        static void Main()
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            string reversedWord = ReverseString(word);

            Console.WriteLine("Reversed word: " + reversedWord);
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
