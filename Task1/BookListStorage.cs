using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    public class BookListStorage
    {
        private string filePath;

        public BookListStorage(string path)
        {
            filePath = path;
        }

        public BookListStorage() : this("BookList.txt")
        { }

        public IEnumerable<Book> ReadBooksFromFile()
        {
            var listOfBooks = new List<Book>();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fileStream))
            {
                while (reader.PeekChar() > -1)
                {
                    var title = reader.ReadString();
                    var author = reader.ReadString();
                    var releaseYear = reader.ReadInt32();
                    var price = reader.ReadDecimal();

                    listOfBooks.Add(new Book(title, author, releaseYear, price));
                }
            }
                return listOfBooks;
        }

        public void WriteBooksToFile(IEnumerable<Book> bookList)
        {
            if (bookList == null)
                throw new ArgumentException();

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                foreach (var book in bookList)
                {
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.ReleaseYear);
                    writer.Write(book.Price);
                }
            }
        }
    }
}
