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
            IRepo repo = Factory.Create();
            [Route("home/new/{query}")]
            [AcceptVerbs("GET")]
            public IHttpActionResult Car()
            {
                CarViewModel car = new CarViewModel();
                CarResponse carResponse = new CarResponse();
                if (dvd == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(car);
                }
            }
        }
}