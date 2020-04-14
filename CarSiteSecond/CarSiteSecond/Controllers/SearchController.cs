using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CarSiteSecond.Data;
using CarSiteSecond.Models;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.ViewModels;

namespace CarSiteSecond.Controllers
{
    public class SearchController : ApiController
    {
        //GETs by category for searches.
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class DVDController : ApiController
        {
            //IRepo repo = Factory.Create();
            //[Route("home/new/{term}/minP/maxP/minY/maxY")]
            //[AcceptVerbs("GET")]
            //public IHttpActionResult Car()
            
                //WHERE CustomerName LIKE '%or%'
                //IRepo repo = Factory.Create();
                //CarResponse carResponse = repo.GetCarsAll(new CarRequest());
                //MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                //ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                //SpecialResponse specialResponse = repo.GetSpecialsAll(new SpecialRequest());
                //foreach (var c in carResponse.Cars)
                //{
                //    if ((LIKE %term% || LIKE %term% || LIKE %term% ) && min < && max > etc)
                //    {
                //        model.HMCVMs.Add(new HomeCarViewModel(c.id, c.PictureSrc, c.Year,
                //            //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                //            makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).MakeID).MakeName,
                //            modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).ModelName, c.SalePrice));
                //    }
                //}
                //List<CarViewModel> car = new List<CarViewModel>;
                //CarResponse carResponse = new CarResponse();
                //if (dvd == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    return Ok(car);
                //}
            }
        }
    }
