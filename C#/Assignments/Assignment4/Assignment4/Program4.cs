using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Books
    {
        private string bookName;
        private string authorName;

        public Books(string bookName, string authorities)
        {
            this.bookName = bookName;
            this.authorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine("Book Details:");
            Console.WriteLine($"Book Name: {bookName}");
            Console.WriteLine($"Author Name: {authorName}");
            Console.Read();
        }
    }

    public class Program4
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the Book Name: ");
            string bookName = Console.ReadLine();

            Console.Write("Enter the Author Name: ");
            string authorName = Console.ReadLine();

            Books book = new Books(bookName, authorName);

            book.Display();
        }
    }
}
