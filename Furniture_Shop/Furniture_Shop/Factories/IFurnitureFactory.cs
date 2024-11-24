using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Shop.Factories
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
}
