using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
    public class BinarySerializerStorage : IStorage
    {
        private string filePath;

        public BinarySerializerStorage(string path)
        {
            filePath = path;
        }

        public BinarySerializerStorage() : this("BookListByDefault.txt")
        { }

        public IEnumerable<Book> LoadFromFile()
        {
            var listOfBooks = new List<Book>();
                        
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var binaryFormatter = new BinaryFormatter();
                listOfBooks = (List<Book>)binaryFormatter.Deserialize(fileStream);
            }

            return listOfBooks;
        }

        public void SaveToFile(IEnumerable<Book> bookList)
        {
            if (bookList == null)
                throw new ArgumentException();

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, bookList);
            }
        }
    }
}
