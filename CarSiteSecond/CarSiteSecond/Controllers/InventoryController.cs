using CarSiteSecond.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSiteSecond.Models;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.Data;
using CarSiteSecond.Data.Repos;
using CarSiteSecond.ViewModels;

namespace CarSiteSecond.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Used()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            CarViewModel model = new CarViewModel();
            IRepo repo = Factory.Create();
            Car car = new Car();
            if(id != null)
            {
                car.id = (int)id;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            if (carResponse.Cars.FirstOrDefault().id != 0)
            {
                MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                model.id = carResponse.Cars.FirstOrDefault().id;
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
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}