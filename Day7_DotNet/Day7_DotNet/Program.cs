using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_DotNet
{
    public class NameEmptyException : Exception
    {
        public NameEmptyException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your name:");

            string name = Console.ReadLine();

            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new NameEmptyException("provide valid name");
                }

                string uppercase = name.ToUpper();

                Console.WriteLine($" name in uppercase is: {uppercase}");
            }
            catch (NameEmptyException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
            Console.Read();
        }
    }
}
