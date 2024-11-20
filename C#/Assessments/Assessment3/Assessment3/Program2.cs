using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box operator +(Box box1, Box box2)
        {
            double newLength = box1.Length + box2.Length;
            double newBreadth = box1.Breadth + box2.Breadth;
            return new Box(newLength, newBreadth);
        }
        public void Display()
        {
            Console.WriteLine($"Box Details: Length = {Length}, Breadth = {Breadth}");
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter measurements for Box 1:");
            Console.Write("Length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);

            Console.WriteLine("\nEnter measurements for Box 2:");
            Console.Write("Length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            Box box2 = new Box(length2, breadth2);

            Console.WriteLine("\nBox 1:");
            box1.Display();

            Console.WriteLine("Box 2:");
            box2.Display();

            Box box3 = box1 + box2;

            Console.WriteLine("\nExpected result (Box 3):");
            box3.Display();

            Console.Read();
        }
    }
}
