using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program2
    {
        static void Main(string[] args)
        {
            string[] data = new string[]
            {
            "Hello, World!",
            "Welcome to C#.net training.",
            "array of strings example.",
            };

            string filePath = "C:\\Users\\chiramyam\\OneDrive - Infinite Computer Solutions (India) Limited\\Desktop\\output.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in data)
                    {
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine($"Text written to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.Read();
        }
    }

}
