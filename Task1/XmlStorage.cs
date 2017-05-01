using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class XmlSerializerStorage : IStorage
    {
        private string filePath;

        public XmlSerializerStorage(string path)
        {
            filePath = path;
        }

        public XmlSerializerStorage() : this("BookListByDefault.txt")
        { }

        public IEnumerable<Book> LoadFromFile()
        {
            var listOfBooks = new List<Book>();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var xmlFormatter = new XmlSerializer(typeof(List<Book>));
                listOfBooks = (List<Book>)xmlFormatter.Deserialize(fileStream);
            }

            return listOfBooks;
        }

        public void SaveToFile(IEnumerable<Book> bookList)
        {
            if (bookList == null)
                throw new ArgumentException();

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var xmlFormatter = new XmlSerializer(typeof(List<Book>));
                xmlFormatter.Serialize(fileStream, bookList);
            }
        }
    }
}
