using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //1st time instantiation
            MySingleTon obj1 = MySingleTon.GetInstance();
            obj1.ShowDetails("msg from object 1");

            //2nd time instantiation
            MySingleTon obj2 = MySingleTon.GetInstance();
            obj2.ShowDetails("msg from object 2");

            Console.Read();
        }
    }
}
