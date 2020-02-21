using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Models;
using Item_Manager.Data;
using System.IO;

namespace Item_Manager.Logic
{
    //add, edit, list all, search by a unique identifier, and delete from your list of items
    public class Features
    {
        private IBookRepo _selector;

        public Features(IBookRepo concrete)
        {
            _selector = concrete;
        }


        public string errorFNF = "File not found.";


        public bool Add(string title, string authorFirst, string authorLast, int pageCount, int chapterCount)
        {
            try
            {
                int currentCount = _selector.ReturnAll().Count();
                Book book = new Book();
                
                book.Title = title;
                book.AuthorFirstName = authorFirst;
                book.AuthorLastName = authorLast;
                book.PageCount = pageCount;
                book.ChapterCount = chapterCount;

                _selector.Add(book);
                return currentCount < _selector.ReturnAll().Count();
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(string title, string authorFirst, string authorLast, int pageCount, int chapterCount, int index)
        {
            try
            {
                Book currentBook = _selector.ReturnBookByIndex(index);
                Book book = new Book();
                book.Title = title;
                book.AuthorFirstName = authorFirst;
                book.AuthorLastName = authorLast;
                book.PageCount = pageCount;
                book.ChapterCount = chapterCount;
                _selector.Edit(book, index);

                return //Checks each property of the old book (current) against new book (result of the Edit method)
                       //Will return true if any of them differ
                   currentBook.Title != _selector.ReturnBookByIndex(index).Title
                || currentBook.AuthorFirstName != _selector.ReturnBookByIndex(index).AuthorFirstName
                || currentBook.AuthorLastName != _selector.ReturnBookByIndex(index).AuthorLastName
                || currentBook.PageCount != _selector.ReturnBookByIndex(index).PageCount
                || currentBook.ChapterCount != _selector.ReturnBookByIndex(index).ChapterCount;
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
        }

        public List<Book> ListAll()
        {
            try
            {
                return _selector.ReturnAll();
            }
            catch (FileNotFoundException ex)
            {
                List<Book> emptyBook = new List<Book>();
                emptyBook = null;
                return emptyBook;
            }
        }

        public Book SearchByIndex(int index, out bool isNull)
        {
            if (index  >= _selector.ReturnAll().Count())
            {
                Book book = new Book();
                isNull = true;
                return book;
            }

            else
            {
                Book book = _selector.ReturnBookByIndex(index);
                isNull = false;
                return book;
            }
        }

        public int DeleteAll()
        {
            List<Book> list = _selector.ReturnAll();
            int count = list.Count();
            for (int i = 0; i < count; i++)
            {
                _selector.Delete(i);
            }
            return count;
        }
    }
}
