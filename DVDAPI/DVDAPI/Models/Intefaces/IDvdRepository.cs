using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;

namespace DVDAPI.Models.Intefaces
{
    public interface IDvdRepository
    {
        ResponseDVDs GetAll();
        ResponseDVDs GetByID(int id);
        ResponseDVDs GetByDirector(string director);
        ResponseDVDs GetByRating(string rating);
        ResponseDVDs GetByTitle(string title);
        ResponseDVDs GetByYear(int year);
        ResponseDVDs DeleteDVD(int id);
        ResponseDVDs NewDVD(DVD dvd);
        ResponseDVDs UpdateDVD(int id, DVD dvd);
    }
}
