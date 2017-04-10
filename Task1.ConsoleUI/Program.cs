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
            Book book1 = new Book("first", "F", 2000, 15);
            Book book2 = new Book("second", "B", 1996, 20);
            Book book3 = new Book("third", "D", 1986, 5);
            Book book4 = new Book("fourth", "C", 2003, 42);
            Book book5 = new Book("fifth", "W", 2013, 65);

            var firstBookListService = new BookListService();
            var secondBookListService = new BookListService();

            firstBookListService.AddBook(book1);
            firstBookListService.AddBook(book2);
            firstBookListService.AddBook(book3);
            firstBookListService.AddBook(book4);
            firstBookListService.AddBook(book5);
            firstBookListService.SaveBooksInStorage(storage);

            var bookList = storage.ReadBooksFromFile();
            foreach (var x in bookList)
                Console.WriteLine(x);
            Console.WriteLine();

            secondBookListService.LoadBooksFromStorage(storage);
            secondBookListService.SortBooksByTag(new SortBooksByTitle());
            foreach (var x in secondBookListService)
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
