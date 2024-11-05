using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SaleDetails
    {
        private int salesNo;
        private int productNo;
        private decimal price;
        private DateTime dateOfSale;
        private int qty;
        private decimal totalAmount;

        public SaleDetails(int salesNo, int productNo, decimal price, int qty, DateTime dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;

            Sales(); 
        }

        public void Sales()
        {
            totalAmount = qty * price;
        }

        public static void ShowData(int salesNo, int productNo, decimal price, int qty, DateTime dateOfSale, decimal totalAmount)
        {
            Console.WriteLine("Sale Details:");
            Console.WriteLine($"Sales No: {salesNo}");
            Console.WriteLine($"Product No: {productNo}");
            Console.WriteLine($"Price: {price:C}"); 
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Date of Sale: {dateOfSale.ToShortDateString()}");
            Console.WriteLine($"Total Amount: {totalAmount:C}"); 
            Console.WriteLine(); 
        }

        public void DisplaySaleDetails()
        {
            ShowData(salesNo, productNo, price, qty, dateOfSale, totalAmount);
        }
    }

    class Program
    {
        static void Main()
        {
            SaleDetails sale = new SaleDetails(1, 101, 29.99m, 5, DateTime.Now);

            sale.DisplaySaleDetails();

            SaleDetails anotherSale = new SaleDetails(2, 102, 39.99m, 3, DateTime.Now);
            anotherSale.DisplaySaleDetails();
        }
    }
}
