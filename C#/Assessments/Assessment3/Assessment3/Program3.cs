using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Program3
    {
        static void Main()
        {
            string filePath = "C:\\DotNet_Training\\C#\\Assessments\\Assessment3\\Assessment3\\Assessment3-Q3"; 

            Console.WriteLine("Enter some text to append to the file:");
            string textToAppend = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(textToAppend);
                }

                Console.WriteLine("The text is appended to " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }

            Console.Read();
        }
    }
}
