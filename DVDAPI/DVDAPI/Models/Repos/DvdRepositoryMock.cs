using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;

namespace DVDAPI.Models.Repos
{

//('Tremors', 'Ron Underwood', 'PG-13', '1990', 'Worms!'),
//('Tremors II: Aftershocks', 'S.S. Wilson', 'PG-13', '1996', 'More worms!'),
//('Tremors 3: Back to Perfection', 'S.S. Wilson', 'PG', '2001', 'Even more worms!'),
//('Tremors 4: The Legend Begins', 'S.S. Wilson', 'PG-13', '2004', 'Really old worms!'),
//('Tremors 5: Bloodlines', 'Don Michael Paul', 'PG-13', '2015', 'Flying worms!'),
//('Tremors: A Cold Day in Hell', 'Don Michael Paul', 'PG-13', '2018', 'Frozen worms!')
    public class DvdRepositoryMock : IDvdRepository
    {
        //Why is this not working?
        //DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
        //List<DVD> DvdLibrary = new List<DVD>();
        //DvdLibrary.Add(Tremors);
        public ResponseDVDs DeleteDVD(int id)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.DvdId == id).ToList();
            if(DvdLibrary.FirstOrDefault(x => x.DvdId == id) != null)
            {
                response.DVDs.Add(DvdLibrary.FirstOrDefault(x => x.DvdId == id));
                DvdLibrary.RemoveAt(DvdLibrary.IndexOf(DvdLibrary.FirstOrDefault(x => x.DvdId == id)));
                response.Success = true;
                response.Message = "Success! The included DVD was deleted.";
            }
            else
            {
                response.Success = false;
                response.Message = "There was no DVD with that ID.";
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetAll()
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary;
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByDirector(string director)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.Director == director).ToList();
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByID(int id)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.DvdId == id).ToList();
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByRating(string rating)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.Rating == rating).ToList();
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByTitle(string title)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.Title == title).ToList();
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByYear(DateTime year)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary.Where(x => x.ReleaseYear == year).ToList();
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs NewDVD(DVD dvd)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            DvdLibrary.Add(dvd);
            ResponseDVDs response = new ResponseDVDs();
            response.DVDs = DvdLibrary;
            response.Success = true;
            response.Message = "Success!";
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs UpdateDVD(int id, DVD dvd)
        {
            DVD Tremors = new DVD(0, "Tremors", "Ron Underwood", "PG-13", DateTime.Parse("1990"), "Worms!");
            List<DVD> DvdLibrary = new List<DVD>();
            DvdLibrary.Add(Tremors);
            ResponseDVDs response = new ResponseDVDs();
            if (DvdLibrary.FirstOrDefault(x => x.DvdId == id) != null)
            {
                response.DVDs.Add(DvdLibrary.FirstOrDefault(x => x.DvdId == id));
                DvdLibrary.RemoveAt(DvdLibrary.IndexOf(DvdLibrary.FirstOrDefault(x => x.DvdId == id)));
                DvdLibrary.Add(dvd);
                response.Success = true;
                response.Message = "Success! The included DVD was updated.";
            }
            else
            {
                response.Success = false;
                response.Message = "There was no DVD with that ID.";
            }
            return response;
            throw new NotImplementedException();
        }
    }
}