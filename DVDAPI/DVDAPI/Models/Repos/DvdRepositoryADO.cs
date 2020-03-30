using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;

namespace DVDAPI.Models.Repos
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public ResponseDVDs DeleteDVD(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetAll()
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByYear(DateTime year)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs NewDVD(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public ResponseDVDs UpdateDVD(int id, DVD dvd)
        {
            throw new NotImplementedException();
        }
    }
}