using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService : IEnumerable<Book>
    {
        private List<Book> bookList;

        public BookListService()
        {
            bookList = new List<Book>();
        }

        public BookListService(IEnumerable<Book> books)
        {
            bookList = new List<Book>(books);
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            if (bookList.Contains(book))
                throw new ArgumentException("This book already exists");

            bookList.Add(book);
        }
        
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            if (!bookList.Contains(book))
                throw new ArgumentException("There is no such book");

            bookList.Remove(book);
        }

        public Book FindBookByTag(Predicate<Book> tag)
        {
            return bookList.Find(tag);
        }
        
        public void SortBooksByTag(Comparison<Book> tag)
        {
            bookList.Sort(tag);
        }

        public void SortBooksByTag(IComparer<Book> tag)
        {
            bookList.Sort(tag);
        }

        public void LoadBooksFromStorage(BookListStorage storage)
        {
            bookList = new List<Book>(storage.ReadBooksFromFile());
        }

        public void SaveBooksInStorage(BookListStorage storage)
        {
            storage.WriteBooksToFile(bookList);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bookList.GetEnumerator();
        }
    }
}
