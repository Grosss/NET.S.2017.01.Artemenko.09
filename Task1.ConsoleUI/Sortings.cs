using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.ConsoleUI
{
    class SortBooksByTitle : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book lhs, Book rhs)
        {
            return string.Compare(lhs.Title, rhs.Title, StringComparison.OrdinalIgnoreCase);
        }
    }

    class SortBooksByAuthor : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book lhs, Book rhs)
        {
            return string.Compare(lhs.Author, rhs.Author, StringComparison.OrdinalIgnoreCase);
        }
    }

    class SortBooksByReleaseYear : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book lhs, Book rhs)
        {
            return lhs.ReleaseYear - rhs.ReleaseYear;
        }
    }

    class SortBooksByPrice : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book lhs, Book rhs)
        {
            return decimal.Compare(lhs.Price, rhs.Price);
        }
    }
}
