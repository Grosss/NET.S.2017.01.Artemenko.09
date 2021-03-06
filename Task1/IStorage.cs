﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IStorage
    {
        IEnumerable<Book> LoadFromFile();
        void SaveToFile(IEnumerable<Book> bookList);
    }
}
