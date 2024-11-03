using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class DaytoName
    {
        public static void Main()
        {
            int num;

            Console.Write("\n\n");
            Console.Write("Accept day number and display its equivalent day name in word:\n");


            Console.Write("Input Day No : ");
            num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.Write("Monday \n");
                    break;
                case 2:
                    Console.Write("Tuesday \n");
                    break;
                case 3:
                    Console.Write("Wednesday \n");
                    break;
                case 4:
                    Console.Write("Thursday \n");
                    break;
                case 5:
                    Console.Write("Friday \n");
                    break;
                case 6:
                    Console.Write("Saturday \n");
                    break;
                case 7:
                    Console.Write("Sunday  \n");
                    break;
                default:
                    Console.Write("Incorrect day number. \n");
                    break;
            }
        }
    }
}
