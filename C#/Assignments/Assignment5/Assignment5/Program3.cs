using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine(" File doesn't exist.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                 int lineCount = lines.Length;
                Console.WriteLine($"Number of lines in file is: {lineCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.Read();
        }
    }
}
