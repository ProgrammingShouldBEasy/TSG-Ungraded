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
        private string _filePath;
        public string errorFNF = "File not found.";

        public Features(string filepath)
        {
            _filePath = filepath;
        }

        public Features()
        {
            _filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\Item Manager\Item Manager\Data\BookList.txt";
        }



        public bool Add(string title, string author, int pageCount, int chapterCount)
        {
            BookRepository bookShelf = new BookRepository(_filePath);
            try
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
            catch (FileNotFoundException ex)
            {
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(string title, string author, int pageCount, int chapterCount, int index)
        {
            try
            {
                BookRepository bookShelf = new BookRepository(_filePath);
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
            catch (FileNotFoundException ex)
            {
                return false;
            }
        }

        public List<Book> ListAll()
        {
            try
            {
                BookRepository bookShelf = new BookRepository(_filePath);
                return bookShelf.ReturnAll();
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
            BookRepository bookShelf = new BookRepository(_filePath);
            if (index  >= bookShelf.ReturnAll().Count())
            {
                Book book = new Book();
                isNull = true;
                return book;
            }

            else
            {
                Book book = bookShelf.ReturnBookByIndex(index);
                isNull = false;
                return book;
            }
        }

        public int DeleteAll()
        {
            BookRepository bookShelf = new BookRepository(_filePath);
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
