using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Manager.Models
{
    public interface IBookRepo
    {
        //list, add, edit, returnByTitle, delete
        List<Book> ReturnAll();

        void Add(Book book);

        void Edit(Book book, int index);

        Book ReturnBookByIndex(int index);

        void Delete(int index);
    }
}
