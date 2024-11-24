using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern
{
    public sealed class MySingleTon
    {
        private static int counter = 0;

        private static MySingleTon sobj = null;

        public static MySingleTon GetInstance()
        {
            if(sobj == null)
            {
                sobj = new MySingleTon();
            }
            return sobj;
        }

        private MySingleTon()
        {
            counter++;
            Console.WriteLine("Counter value is " + counter.ToString());
        }

        public void ShowDetails(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
