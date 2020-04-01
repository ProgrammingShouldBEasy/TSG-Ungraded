using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;
using DVDAPI.Models.EF;

namespace DVDAPI.Models.Repos
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public ResponseDVDs DeleteDVD(int id)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            if (repo.DVDs.FirstOrDefault(x => x.id == id) != null)
            {
                DVD dvd = new DVD();
                dvd.director = repo.DVDs.FirstOrDefault(x => x.id == id).director;
                dvd.dvdId = id;
                dvd.notes = repo.DVDs.FirstOrDefault(x => x.id == id).notes;
                dvd.rating = repo.DVDs.FirstOrDefault(x => x.id == id).rating;
                dvd.releaseYear = repo.DVDs.FirstOrDefault(x => x.id == id).year;
                repo.DVDs.Remove(repo.DVDs.FirstOrDefault(x => x.id == id));
                response.DVDs.Add(dvd);
                repo.SaveChanges();
                response.Message = "Success!";
                response.Success = true;
                return response;
            }
            else
            {
                response.Message = "Failure.";
                response.Success = false;
                return response;
            }
            throw new NotImplementedException();
        }

        public ResponseDVDs GetAll()
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach( var item in repo.DVDs.Where(x => x.id >= 0).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByDirector(string director)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.director != null).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByID(int id)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.id == id).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByRating(string rating)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.rating == rating).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByTitle(string title)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.title == title).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByYear(int year)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.year == year).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, item.year, item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs NewDVD(DVD dvd)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            if (dvd != null)
            {
                DVDs dvdToAdd = new DVDs();
                dvdToAdd.id = dvd.dvdId;
                dvdToAdd.notes = dvd.notes;
                dvdToAdd.rating = dvd.rating;
                dvdToAdd.title = dvd.title;
                dvdToAdd.year = dvd.releaseYear;
                dvdToAdd.director = dvd.director;
                response.DVDs.Add(dvd);
                repo.DVDs.Add(dvdToAdd);
                repo.SaveChanges();
                response.Message = "Success!";
                response.Success = true;
                return response;
            }
            else
            {
                response.Message = "Failure.";
                response.Success = false;
                return response;
            }
            throw new NotImplementedException();
        }

        public ResponseDVDs UpdateDVD(int id, DVD dvd)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            if (dvd != null)
            {
                DVDs dvdToUpdate = new DVDs();
                dvdToUpdate.id = dvd.dvdId;
                dvdToUpdate.notes = dvd.notes;
                dvdToUpdate.rating = dvd.rating;
                dvdToUpdate.title = dvd.title;
                dvdToUpdate.year = dvd.releaseYear;
                dvdToUpdate.director = dvd.director;
                repo.DVDs.Remove(repo.DVDs.FirstOrDefault(x => x.id == id));
                repo.DVDs.Add(dvdToUpdate);
                response.DVDs.Add(dvd);
                repo.SaveChanges();
                response.Message = "Success!";
                response.Success = true;
                return response;
            }
            else
            {
                response.Message = "Failure.";
                response.Success = false;
                return response;
            }
            throw new NotImplementedException();
        }
    }
}