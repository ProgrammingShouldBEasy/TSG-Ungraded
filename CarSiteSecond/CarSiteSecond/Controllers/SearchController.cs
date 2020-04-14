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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        IRepo repo = Factory.Create();
        [Route("Inventory/New/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetNew()
        {
            CarViewModel model = new CarViewModel();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            foreach (Car a in carResponse.Cars)
            {
                MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                model.id = a.id;
                model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
                //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
                model.Model = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
                model.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                model.MSRP = carResponse.Cars.FirstOrDefault().MSRP;
                model.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                model.SalePrice = carResponse.Cars.FirstOrDefault().SalePrice;
                model.Trans = carResponse.Cars.FirstOrDefault().Transmission;
                model.VIN = carResponse.Cars.FirstOrDefault().VIN;
                model.Year = carResponse.Cars.FirstOrDefault().Year;
                model.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;
                model.Description = carResponse.Cars.FirstOrDefault().Description;
                if(model.Year == DateTime.Now.Year)
                {
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Inventory/Used/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsed()
        {
            CarViewModel model = new CarViewModel();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            foreach (Car a in carResponse.Cars)
            {
                MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
                model.id = a.id;
                model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
                //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
                model.Model = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
                model.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                model.MSRP = carResponse.Cars.FirstOrDefault().MSRP;
                model.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                model.SalePrice = carResponse.Cars.FirstOrDefault().SalePrice;
                model.Trans = carResponse.Cars.FirstOrDefault().Transmission;
                model.VIN = carResponse.Cars.FirstOrDefault().VIN;
                model.Year = carResponse.Cars.FirstOrDefault().Year;
                model.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;
                model.Description = carResponse.Cars.FirstOrDefault().Description;
                if (model.Year != DateTime.Now.Year)
                {
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Sales/Index/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSales()
        {
            CarViewModel model = new CarViewModel();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            foreach (Car a in carResponse.Cars)
            {
                MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
                model.id = a.id;
                model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
                //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
                model.Model = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
                model.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                model.MSRP = carResponse.Cars.FirstOrDefault().MSRP;
                model.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                model.SalePrice = carResponse.Cars.FirstOrDefault().SalePrice;
                model.Trans = carResponse.Cars.FirstOrDefault().Transmission;
                model.VIN = carResponse.Cars.FirstOrDefault().VIN;
                model.Year = carResponse.Cars.FirstOrDefault().Year;
                model.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;
                model.Description = carResponse.Cars.FirstOrDefault().Description;
                if (model.Year != DateTime.Now.Year && saleResponse.Sales.FirstOrDefault(x => x.CarID == model.id) == null)
                {
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Admin/Vehicles/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesAdmin()
        {
            CarViewModel model = new CarViewModel();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            foreach (Car a in carResponse.Cars)
            {
                MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
                model.id = a.id;
                model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
                //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
                model.Model = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
                model.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                model.MSRP = carResponse.Cars.FirstOrDefault().MSRP;
                model.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                model.SalePrice = carResponse.Cars.FirstOrDefault().SalePrice;
                model.Trans = carResponse.Cars.FirstOrDefault().Transmission;
                model.VIN = carResponse.Cars.FirstOrDefault().VIN;
                model.Year = carResponse.Cars.FirstOrDefault().Year;
                model.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;
                model.Description = carResponse.Cars.FirstOrDefault().Description;
                if (model.Year != DateTime.Now.Year && saleResponse.Sales.FirstOrDefault(x => x.CarID == model.id) == null)
                {
                    list.Add(model);
                }
            }
            return Ok(list);
        }
        //GETs by category for searches.
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public class DVDController : ApiController
        //{
        //    IDvdRepository Repo = Factory.Create();
        //    [Route("dvd/{id}")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult Dvd(int id)
        //    {
        //        DVD dvd = Repo.GetByID(id).DVDs.FirstOrDefault(x => x.dvdId == id);
        //        if (dvd == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(dvd);
        //        }
        //    }

        //    [Route("dvds/title/{title}")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult Title(string title)
        //    {
        //        return Ok(Repo.GetByTitle(title).DVDs);
        //    }

        //    [Route("dvds")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult All()
        //    {
        //        return Ok(Repo.GetAll().DVDs);
        //    }

        //    [Route("dvds/year/{releaseYear}")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult Year(string releaseYear)
        //    {
        //        return Ok(Repo.GetByYear(int.Parse(releaseYear)).DVDs);
        //    }

        //    [Route("dvds/director/{directorName}")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult Director(string directorName)
        //    {
        //        return Ok(Repo.GetByDirector(directorName).DVDs);
        //    }

        //    [Route("dvds/rating/{rating}")]
        //    [AcceptVerbs("GET")]
        //    public IHttpActionResult Rating(string rating)
        //    {
        //        return Ok(Repo.GetByRating(rating).DVDs);
        //    }

        //    [Route("dvd")]
        //    [AcceptVerbs("POST")]
        //    public IHttpActionResult New(AddDVDRequest request)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        else
        //        {
        //            DVD dvd = new DVD();
        //            dvd.director = request.director;
        //            dvd.dvdId = Repo.GetAll().DVDs.Count;
        //            dvd.notes = request.notes;
        //            dvd.rating = request.rating;
        //            dvd.releaseYear = int.Parse(request.releaseYear);
        //            dvd.title = request.title;
        //            Repo.NewDVD(dvd);
        //            return Created($"dvd/{dvd.dvdId}", dvd);
        //        }
        //    }

        //    [Route("dvd/{id}")]
        //    [AcceptVerbs("PUT")]
        //    public IHttpActionResult Edit(int id, AddDVDRequest request)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        else
        //        {
        //            if (Repo.GetByID(id) != null)
        //            {
        //                DVD dvd = new DVD(Repo.GetAll().DVDs.Count, request.title, request.director, request.rating, int.Parse(request.releaseYear), request.notes);
        //                Repo.UpdateDVD(id, dvd);
        //                return Ok(dvd);
        //            }
        //            return BadRequest("No DVD exists with that id.");
        //        }
        //    }

        //    [Route("dvd/{id}")]
        //    [AcceptVerbs("DELETE")]
        //    public IHttpActionResult Delete(int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        else
        //        {
        //            if (Repo.GetByID(id) != null)
        //            {
        //                Repo.DeleteDVD(id);
        //                return Ok();
        //            }
        //            return BadRequest("No DVD exists with that id.");
        //        }
        //    }
        //}
    }
}

