using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment3ADO
{
    class Program
    {
        static void Main()
        {
            string conn = "Server=ICS-LT-D244D6D4\\SQLEXPRESS;Database=db13;Integrated Security=true;";
            string productName = "COCA COLA";
            double price = 120.0f;

            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                using (SqlCommand command = new SqlCommand("InsertProduct", connect))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Price", price);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int generatedProductId = reader.GetInt32(0);
                            Console.WriteLine($"Generated Product ID: {generatedProductId}");
                        }

                        if (reader.NextResult())
                        {
                            Console.WriteLine("Product Detail:");
                            while (reader.Read())
                            {
                                int productId = reader.GetInt32(0);
                                string name = reader.GetString(1);

                                double priceValue = reader.GetDouble(3);
                                double discountedPrice = reader.GetDouble(3);

                                Console.WriteLine($"Product ID: {productId}, Name: {name}, Price: {priceValue}, Discounted Price: {discountedPrice}");
                            }
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}
