using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        public string Title { get; }
        public string Author { get; }
        public int ReleaseYear { get; }
        public decimal Price { get; set; }

        public Book(string title, string author, int releaseYear, decimal price)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Price = price;
        }

        public Book() : this(string.Empty, string.Empty, default (int), default (decimal))
        { }

        #region Overrided Object methods

        public override string ToString()
        {                                    
            return $"Title: {Title}, author: {Author}, release year: {ReleaseYear}, price: {Price}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Title.GetHashCode();
                hash = hash * 23 + Author.GetHashCode();
                hash = hash * 23 + ReleaseYear.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((Book)obj);
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(this, book))
                return true;

            if (ReferenceEquals(null, book))
                return false;

            if (Title != book.Title || Author != book.Author 
                || ReleaseYear != book.ReleaseYear || Price != book.Price)
                return false;

            return true;
        }
               
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
                return true;

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1;

            return CompareTo((Book)obj);
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                return 1;

            return ToString().CompareTo(other.ToString());
        }
    }
}
