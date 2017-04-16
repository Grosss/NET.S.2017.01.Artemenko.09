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
            Book book1 = new Book("first", "F", 2000, 15);
            Book book2 = new Book("second", "B", 1996, 20);
            Book book3 = new Book("third", "D", 1986, 5);
            Book book4 = new Book("fourth", "C", 2003, 42);
            Book book5 = new Book("fifth", "W", 2013, 65);

            BookListStorage storage = new BookListStorage("BookList.txt");
            var firstBookListService = new BookListService();
            var secondBookListService = new BookListService();

            firstBookListService.AddBook(book1);
            firstBookListService.AddBook(book2);
            firstBookListService.AddBook(book3);
            firstBookListService.AddBook(book4);
            firstBookListService.AddBook(book5);
            foreach (var x in firstBookListService.GetBookList())
                Console.WriteLine(x);
            Console.WriteLine();
                        
            firstBookListService.SaveBooksInStorage(storage);                        
            foreach (var x in storage.LoadFromFile())
                Console.WriteLine(x);
            Console.WriteLine();

            secondBookListService.LoadBooksFromStorage(storage);
            secondBookListService.SortBooksByTag(new SortBooksByTitle());
            foreach (var x in secondBookListService.GetBookList())
                Console.WriteLine(x);
            Console.WriteLine();

            secondBookListService.SortBooksByTag(CompareByPrice);
            foreach (var x in secondBookListService.GetBookList())
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine(secondBookListService.FindBookByTag(FindBySpecialTitle));
            
            Console.ReadLine();
        }

        public static int CompareByPrice(Book lhs, Book rhs)
        {
            return decimal.Compare(lhs.Price, rhs.Price);
        }

        public static bool FindBySpecialTitle(Book book)
        {
            return book.Title == "third";
        }
    }
}
