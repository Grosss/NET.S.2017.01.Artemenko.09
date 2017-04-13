using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IStorage
    {
        IEnumerable<Book> ReadBooksFromFile();
        void WriteBooksToFile(IEnumerable<Book> bookList);
    }
}
