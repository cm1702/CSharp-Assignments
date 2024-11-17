using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 7, 2, 30 };
 
            var result = numbers
                .Select(n => new { Number = n, Square = n * n }) 
                .Where(x => x.Square > 20) 
                .ToList();
  
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }

            Console.Read();
        }
    }
}
