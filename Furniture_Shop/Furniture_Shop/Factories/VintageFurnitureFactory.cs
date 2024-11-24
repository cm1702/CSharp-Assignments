using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Shop.Factories
{
    // VintageFurnitureFactory class
    public class VintageFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VintageChair();
        }

        public ISofa CreateSofa()
        {
            return new VintageSofa();
        }
    }
}
