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
                dvd.Director = repo.DVDs.FirstOrDefault(x => x.id == id).director;
                dvd.DvdId = id;
                dvd.Notes = repo.DVDs.FirstOrDefault(x => x.id == id).notes;
                dvd.Rating = repo.DVDs.FirstOrDefault(x => x.id == id).rating;
                dvd.ReleaseYear = DateTime.Parse(repo.DVDs.FirstOrDefault(x => x.id == id).year.ToString());
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
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
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
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
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
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
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
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
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
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
                response.DVDs.Add(dvd);
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByYear(DateTime year)
        {
            DVDEntities repo = new DVDEntities();
            ResponseDVDs response = new ResponseDVDs();
            foreach (var item in repo.DVDs.Where(x => x.year == year.Year).ToList())
            {
                //int dvdId, string title, string director, string rating, DateTime releaseYear, string notes
                DVD dvd = new DVD(item.id, item.title, item.director, item.rating, DateTime.Parse(item.year.ToString()), item.notes);
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
                dvdToAdd.id = dvd.DvdId;
                dvdToAdd.notes = dvd.Notes;
                dvdToAdd.rating = dvd.Rating;
                dvdToAdd.title = dvd.Title;
                dvdToAdd.year = dvd.ReleaseYear.Year;
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
                dvdToUpdate.id = dvd.DvdId;
                dvdToUpdate.notes = dvd.Notes;
                dvdToUpdate.rating = dvd.Rating;
                dvdToUpdate.title = dvd.Title;
                dvdToUpdate.year = dvd.ReleaseYear.Year;
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