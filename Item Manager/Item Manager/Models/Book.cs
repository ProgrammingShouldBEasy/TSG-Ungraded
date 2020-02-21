using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Manager.Models
{
    public class Book
    {
        public Book(string title, string authorFirstName, string authorLastName, int pageCount, int chapterCount)
        {
            Title = title;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            PageCount = pageCount;
            ChapterCount = chapterCount;
        }

        public Book()
        {

        }

        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int PageCount { get; set; }
        public int ChapterCount { get; set; }
    }
}
