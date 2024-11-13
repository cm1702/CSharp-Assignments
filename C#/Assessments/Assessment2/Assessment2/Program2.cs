using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;

        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
    }

    class Program2
    {
        static void Main()
        {
            Product[] products = new Product[10];

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i + 1}:");

                int id;
                while (true)
                {
                    Console.Write("Product ID (integer): ");
                    string idInput = Console.ReadLine();
                    if (int.TryParse(idInput, out id))
                        break;
                    else
                        Console.WriteLine(" Please enter a valid integer for Product ID.");
                }

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                double price;
                while (true)
                {
                    Console.Write("Product Price (decimal): ");
                    string priceInput = Console.ReadLine();
                    if (double.TryParse(priceInput, out price))
                        break;
                    else
                        Console.WriteLine("Invalid input! Please enter a valid number for Price.");
                }

                products[i] = new Product(id, name, price);
                Console.WriteLine();
            }

            var sortedProducts = products.OrderBy(p => p.Price).ToArray();

            Console.WriteLine("Sorted Products based on Price:");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price:C}");
            }
            Console.Read();
        }
    }
}


