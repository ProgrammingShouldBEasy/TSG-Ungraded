using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using Item_Manager.Logic;
using Item_Manager.Data;
using Item_Manager.Models;
using System.IO;

namespace Item_Manager.Tests
{
    [TestFixture]
    public class LogicTests
    {
        //Why is the data layer not receiving the correct filepath?
        private static string testPath = @"C:\Users\Cain\source\repos\TSG Ungraded\Item Manager\Item Manager\Data\BookListTest.txt";
        Features processor = new Features(testPath);

        public List<Book> ReadSeed()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Cain\source\repos\TSG Ungraded\Item Manager\Item Manager\Data\BookListSeed.txt"))
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

        private static string BookWriteToTxt(Book book)
        {
            return $"{book.Title},{book.AuthorFirstName},{book.AuthorLastName},{book.PageCount},{book.ChapterCount}";
        }

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }

            using (StreamWriter sw = new StreamWriter(testPath))
            {
                sw.WriteLine("Title,AuthorLastName,AuthorFirstName,PageCount,ChapterCount");
                foreach (var x in ReadSeed())
                {
                    sw.WriteLine(BookWriteToTxt(x));
                }
            }
        }
        [Test]
        public void Add1()
        {
            processor.Add("", "first last", 0, 0);
            List<Book> newList = processor.ListAll();
            Assert.AreEqual(2, newList.Count());
        }

        [Test]
        public void AddTitle()
        {
            processor.Add("TestTitle", "first last", 0, 0);
            List<Book> list = processor.ListAll();
            Assert.AreEqual("TestTitle", list[1].Title);
        }

        [Test]
        public void AddEmpty()
        {
            processor.Add("", "first last", 0, 0);
            List<Book> list = processor.ListAll();
            Assert.AreEqual(string.Empty, list[1].Title);
        }

        [Test]
        public void EditChanges()
        {
            processor.Edit("", "first last", 1, 0, 0);
            Assert.AreEqual(true, processor.Edit("", "first last", 0, 0, 0));
        }

        [Test]
        public void EditTitle()
        {
            processor.Edit("TestTitle", "first last", 0, 0, 0);
            List<Book> list = processor.ListAll();
            Assert.AreEqual("TestTitle", list[0].Title);
        }

        [Test]
        public void EditNoChanges()
        {
            processor.Edit("", "first last", 0, 0, 0);
            List<Book> list = processor.ListAll();
            Assert.AreEqual(false, processor.Edit("", "first last", 0, 0, 0));
        }

        [Test]
        public void ListAllCount()
        {
            Assert.AreEqual(1, processor.ListAll().Count());
        }

        [Test]
        public void ListAllTitle()
        {
            Assert.AreEqual("RedWall", processor.ListAll()[0].Title);
        }

        [Test]
        public void SearchByIndexTitle()
        {
            bool isNull;
            Assert.AreEqual("RedWall", processor.SearchByIndex(0, out isNull).Title);
            Assert.AreEqual(false, isNull);
        }

        [Test]
        public void SearchByIndexNull()
        {
            bool isNull;
            processor.SearchByIndex(1, out isNull);
            Assert.AreEqual(true, isNull);
        }

        [Test]
        public void DeleteAll()
        {
            Assert.AreEqual(1, processor.DeleteAll());
        }

    }
}
