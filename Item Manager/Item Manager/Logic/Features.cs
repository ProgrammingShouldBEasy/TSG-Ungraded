using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Models;
using Item_Manager.Data;

namespace Item_Manager.Logic
{
    //add, edit, list all, search by a unique identifier, and delete from your list of items
    public class Features
    {
        private static string _filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\Item Manager\Item Manager\Data\BookList.txt";

        BookRepository bookShelf = new BookRepository(_filePath);

        public bool Add(string title, string author, int pageCount, int chapterCount)
        {
            int currentCount = bookShelf.ReturnAll().Count();
            Book book = new Book();
            string[] name = author.Split(' ');
            book.Title = title;
            book.AuthorFirstName = name[0];
            book.AuthorLastName = name[1];
            book.PageCount = pageCount;
            book.ChapterCount = chapterCount;

            bookShelf.Add(book);
            return currentCount < bookShelf.ReturnAll().Count();
        }

        public bool Edit(string title, string author, int pageCount, int chapterCount, int index)
        {
            Book currentBook = bookShelf.ReturnBookByIndex(index);
            Book book = new Book();
            book.Title = title;
            string[] name = author.Split(' ');
            book.AuthorFirstName = name[0];
            book.AuthorLastName = name[1];
            book.PageCount = pageCount;
            book.ChapterCount = chapterCount;
            bookShelf.Edit(book, index);

            return //Checks each property of the old book (current) against new book (result of the Edit method)
                   //Will return true if any of them differ
               currentBook.Title != bookShelf.ReturnBookByIndex(index).Title
            || currentBook.AuthorFirstName != bookShelf.ReturnBookByIndex(index).AuthorFirstName
            || currentBook.AuthorLastName != bookShelf.ReturnBookByIndex(index).AuthorLastName
            || currentBook.PageCount != bookShelf.ReturnBookByIndex(index).PageCount
            || currentBook.ChapterCount != bookShelf.ReturnBookByIndex(index).ChapterCount;
        }

        public List<Book> ListAll()
        {
            return bookShelf.ReturnAll();
        }

        public Book SearchByIndex(int index, out bool isNull)
        {
            Book book = bookShelf.ReturnBookByIndex(index);
            if (book == null)
            {
                isNull = true;
            }

            else
            {
                isNull = false;
            }

            return book;
        }

        public int DeleteAll()
        {
            List<Book> list = bookShelf.ReturnAll();
            int count = list.Count();
            for (int i = 0; i < count; i++)
            {
                bookShelf.Delete(i);
            }
            return count;
        }
    }
}
