using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Models;
using System.IO;

namespace Item_Manager.Data
{
    public class BookRepoTest : IBookRepo
    {
        private List<Book> TestList = new List<Book>() { new Book("book name name name", "author first", "author last", 9876, 333),
                                                            new Book("jkjlkkbknkjn", "mike", "mikkkkkeee", 2, 33),
                                                            new Book("singletitle", "singlefirst", "singlesecond", 200, 10),
                                                            new Book("b", "c", "d", 987654, 3241)};

        //list, add, edit, returnByTitle, delete
        public List<Book> ReturnAll()
        {
            return TestList;
        }

        public void Add(Book book)
        {
            TestList.Add(book);
        }

        public void Edit(Book book, int index)
        {
            TestList[index] = book;
        }

        public Book ReturnBookByIndex(int index)
        {
            return TestList[index];
        }

        public void Delete(int index)
        {
            TestList.RemoveAt(index);
        }
    }
}
