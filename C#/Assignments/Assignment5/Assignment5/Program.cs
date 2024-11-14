using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Books
     {
         public string BookName { get;  set; }
         public string AuthorName { get;  set; }
         public Books(string bookName, string authorName)
         {
             BookName = bookName;
             AuthorName = authorName;
         }

         public void Display()
         {
             Console.WriteLine($"Book Name: {BookName}");
             Console.WriteLine($"Author Name: {AuthorName}");
         }
     }
     public class BookShelf
     {
          Books[] books = new Books[5];

         public Books this[int index]
         {
             get
             {
                 if (index < 0 || index >= books.Length)
                     throw new IndexOutOfRangeException("Index is out of range.");
                 return books[index];
             }
             set
             {
                 if (index < 0 || index >= books.Length)
                     throw new IndexOutOfRangeException("Index is out of range.");
                 books[index] = value;
             }
         }
     }

     class Program
     {
         static void Main(string[] args)
         {
             BookShelf shelf = new BookShelf();

             for (int i = 0; i < 5; i++)
             {
                 Console.WriteLine($"Enter details {i + 1}:");
                 Console.Write("Book Name: ");
                 string bookName = Console.ReadLine();
                 Console.Write("Author Name: ");
                 string authorName = Console.ReadLine();

                 shelf[i] = new Books(bookName, authorName);
             }

             Console.WriteLine("\nBooks in the Shelf:");
             for (int i = 0; i < 5; i++)
             {
                 Console.WriteLine($"\nBook {i + 1}:");
                 shelf[i]?.Display(); 
             }
             Console.Read();
         }
     } 
}
