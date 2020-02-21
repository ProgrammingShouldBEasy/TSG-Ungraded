using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Models;
using System.IO;

namespace Item_Manager.Data
{
    public class BookRepository : IBookRepo
    {
        private string _filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\Item Manager\Item Manager\Data\BookList.txt";


        private string BookWriteToTxt(Book book)
        {
            return $"{book.Title},{book.AuthorFirstName},{book.AuthorLastName},{book.PageCount},{book.ChapterCount}";
        }

        private List<Book> ReadBooksfromFile()
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                List<Book> list = new List<Book>();
                string[] columns;
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Book book = new Book();
                    columns = line.Split(',');
                    book.Title = columns[0];
                    book.AuthorLastName = columns[1];
                    book.AuthorFirstName = columns[2];
                    book.PageCount = int.Parse(columns[3]);
                    book.ChapterCount = int.Parse(columns[4]);
                    list.Add(book);
                }

                return list;
            }
        }

        private void WriteBookstoFile(List<Book> list)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("Title,AuthorLastName,AuthorFirstName,PageCount,ChapterCount");
                foreach (Book x in list)
                {
                    sw.WriteLine(BookWriteToTxt(x));
                }
            }
        }

        //list, add, edit, returnByTitle, delete
        public List<Book> ReturnAll()
        {
            return ReadBooksfromFile();
        }

        public void Add(Book book)
        {
            List<Book> list = ReadBooksfromFile();
            list.Add(book);
            WriteBookstoFile(list);
        }

        public void Edit(Book book, int index)
        {
            List<Book> list = ReadBooksfromFile();
            list[index] = book;
            WriteBookstoFile(list);
        }

        public Book ReturnBookByIndex(int index)
        {
            List<Book> list = ReadBooksfromFile();
            return list[index];
        }

        public void Delete(int index)
        {
            List<Book> list = ReadBooksfromFile();
            list.RemoveAt(index);
            WriteBookstoFile(list);
        }
    }
}
