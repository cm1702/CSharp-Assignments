using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program2
    {
        static void Main()
        {
            List<string> words = new List<string> { "mum", "amsterdam", "bloom" };
 
            var result = words
                .Where(word => word.StartsWith("a") && word.EndsWith("m")) 
                .ToList();
            
            Console.WriteLine(string.Join(", ", result));
 
            Console.Read();
        }
        
    }
}
