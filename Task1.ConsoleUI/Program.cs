using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task1.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListStorage storage = new BookListStorage("BookList.txt");
            Book book1 = new Book("first", "A", 2000, 15);
            Book book2 = new Book("second", "B", 1996, 20);
            var bookList = new List<Book>();
            bookList.Add(book1);
            bookList.Add(book2);
            storage.WriteBooksToFile(bookList);
            var bookL = (List<Book>)storage.ReadBooksFromFile();
            foreach (var x in bookL)
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
