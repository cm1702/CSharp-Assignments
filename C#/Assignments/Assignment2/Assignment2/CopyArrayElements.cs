using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class CopyArrayElements
    {
        static void Main(string[] args)
        {
            int[] src = { 1, 2, 3, 4, 5 };
            int[] dest = new int[src.Length];

            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }

            Console.WriteLine("Original Array:");
            PrintArray(src);

            Console.WriteLine("Copied Array:");
            PrintArray(dest);
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        } 
    }
}
