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

            if (!bookList.Remove(book))
                throw new ArgumentException("There is no such book");            
        }

        public Book FindBookByTag(Predicate<Book> tag)
        {
            if (ReferenceEquals(tag, null))
                throw new ArgumentNullException();

            return bookList.Find(tag);
        }
        
        public void SortBooksByTag(Comparison<Book> tag)
        {
            if (ReferenceEquals(tag, null))
                throw new ArgumentNullException();

            bookList.Sort(tag);
        }

        public void SortBooksByTag(IComparer<Book> tag)
        {
            if (ReferenceEquals(tag, null))
                throw new ArgumentNullException();

            bookList.Sort(tag);
        }

        public void LoadBooksFromStorage(BookListStorage storage)
        {
            if (ReferenceEquals(storage, null))
                throw new ArgumentNullException();

            bookList = new List<Book>(storage.ReadBooksFromFile());
        }

        public void SaveBooksInStorage(BookListStorage storage)
        {
            if (ReferenceEquals(storage, null))
                throw new ArgumentNullException();

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
