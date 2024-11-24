using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory modernFactory = new ModernFurnitureFactory();
            IChair modernChair = modernFactory.CreateChair();
            ISofa modernSofa = modernFactory.CreateSofa();

            Console.WriteLine(modernChair.SitOn());
            Console.WriteLine(modernSofa.LieOn());  

            IFurnitureFactory vintageFactory = new VintageFurnitureFactory();
            IChair vintageChair = vintageFactory.CreateChair();
            ISofa vintageSofa = vintageFactory.CreateSofa();

            Console.WriteLine(vintageChair.SitOn()); 
            Console.WriteLine(vintageSofa.LieOn());   
        }
    }
}
