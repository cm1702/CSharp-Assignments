using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Shop_OneFile
{
    // Abstract Products
    public interface IChair
    {
        string SitOn();
    }

    public interface ISofa
    {
        string LayOn();
    }

    // Concrete Products
    public class ModernChair : IChair
    {
        public string SitOn()
        {
            return "Modern Chair";
        }
    }

    public class ModernSofa : ISofa
    {
        public string LayOn()
        {
            return "Modern Sofa";
        }
    }

    public class VintageChair : IChair
    {
        public string SitOn()
        {
            return "Vintage Chair";
        }
    }

    public class VintageSofa : ISofa
    {
        public string LayOn()
        {
            return "Vintage Sofa";
        }
    }

    // Abstract Factory
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }

    // Concrete Factories
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }

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

    // Provider for Furniture Factories
    public interface IFurnitureFactoryProvider
    {
        IFurnitureFactory GetModernFactory();
        IFurnitureFactory GetVintageFactory();
    }

    public class FurnitureFactoryProvider : IFurnitureFactoryProvider
    {
        public IFurnitureFactory GetModernFactory()
        {
            return new ModernFurnitureFactory();
        }

        public IFurnitureFactory GetVintageFactory()
        {
            return new VintageFurnitureFactory();
        }
    }

    // Client Code
    class Program
    {
        static void ClientCode(IFurnitureFactory factory)
        {
            IChair chair = factory.CreateChair();
            ISofa sofa = factory.CreateSofa();

            Console.WriteLine(chair.SitOn());
            Console.WriteLine(sofa.LayOn());
        }

        static void Main(string[] args)
        {
            IFurnitureFactoryProvider provider = new FurnitureFactoryProvider();

            Console.WriteLine("Modern Furniture:");
            IFurnitureFactory modernFactory = provider.GetModernFactory();
            ClientCode(modernFactory);

            Console.WriteLine("\nVintage Furniture:");
            IFurnitureFactory vintageFactory = provider.GetVintageFactory();
            ClientCode(vintageFactory);

            Console.Read();
        }
    }
}
