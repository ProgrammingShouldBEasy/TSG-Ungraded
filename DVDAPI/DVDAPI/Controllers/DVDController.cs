using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDAPI.Models;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.Repos;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;
using System.Web.Http.Cors;

namespace DVDAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        IDvdRepository Repo = Factory.Create();
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Dvd(int id)
        {
            DVD dvd = Repo.GetByID(id).DVDs.FirstOrDefault(x => x.dvdId == id);
            if(dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Title(string title)
        {
            return Ok(Repo.GetByTitle(title).DVDs);
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(Repo.GetAll().DVDs);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Year(string releaseYear)
        {
            return Ok(Repo.GetByYear(int.Parse(releaseYear)).DVDs);
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Director(string directorName)
        {
            return Ok(Repo.GetByDirector(directorName).DVDs);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Rating(string rating)
        {
            return Ok(Repo.GetByRating(rating).DVDs);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult New(AddDVDRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                DVD dvd = new DVD();
                dvd.director = request.director;
                dvd.dvdId = Repo.GetAll().DVDs.Count;
                dvd.notes = request.notes;
                dvd.rating = request.rating;
                dvd.releaseYear = int.Parse(request.releaseYear);
                dvd.title = request.title;
                Repo.NewDVD(dvd);
                return Created($"dvd/{dvd.dvdId}", dvd);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(int id, AddDVDRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (Repo.GetByID(id) != null)
                {
                    DVD dvd = new DVD(Repo.GetAll().DVDs.Count, request.title, request.director, request.rating, int.Parse(request.releaseYear), request.notes);
                    Repo.UpdateDVD(id, dvd);
                    return Ok(dvd);
                }
                return BadRequest("No DVD exists with that id.");
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (Repo.GetByID(id) != null)
                {
                    Repo.DeleteDVD(id);
                    return Ok();
                }
                return BadRequest("No DVD exists with that id.");
            }
        }
    }
}
