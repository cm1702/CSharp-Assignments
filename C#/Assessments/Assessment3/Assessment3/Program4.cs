using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public delegate int CalcDel(int a, int b);

    class Program4
    {
        static int add(int a, int b)
        {
            return a + b;
        }

        static int subtract(int a, int b)
        {
            return a - b;
        }

        static int multiply(int a, int b)
        {
            return a * b;
        }

        static void Main()
        {
            Console.WriteLine("Enter first no.:");
            int firstNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second no.:");
            int secondNum = Convert.ToInt32(Console.ReadLine());

            CalcDel addDel = new CalcDel(add);
            CalcDel subtractDel = new CalcDel(subtract);
            CalcDel multiplyDel = new CalcDel(multiply);

            int additionRes = addDel(firstNum, secondNum);
            int subtractionRes = subtractDel(firstNum, secondNum);
            int multiplicationRes = multiplyDel(firstNum, secondNum);

            Console.WriteLine($"Addition of {firstNum} and {secondNum} is: {additionRes}");
            Console.WriteLine($"Subtraction of {firstNum} from {secondNum} is: {subtractionRes}");
            Console.WriteLine($"Multiplication of {firstNum} and {secondNum} is: {multiplicationRes}");

            Console.Read();
        }
    }
}

