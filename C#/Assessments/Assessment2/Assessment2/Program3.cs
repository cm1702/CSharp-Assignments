using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer:");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());

                if (input < 0)
                {

                    throw new ArgumentOutOfRangeException(nameof(input), "The number cannot be negative.");
                }

                Console.WriteLine("You entered a valid number: " + input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }



}
