using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_in_CSharp
{
    class Program
    {
        private static int counter = 0;
        private static object lockobj = new object();

        static void IncrementCtr()
        {
            for(int i = 0; i<5000; i++)
            {
                lock (lockobj)
                {
                    counter++;
                }
            }
            Console.WriteLine("Counter value is: " + counter);
        }

        public static void Main(string[] args)
        {
            Thread t1 = new Thread(IncrementCtr);
            Thread t2 = new Thread(IncrementCtr);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("counter :" + counter);
            Console.Read();
        }
    }
}
