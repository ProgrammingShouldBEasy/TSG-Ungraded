using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.Identity;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.Data.Repos;
using CarSiteSecond.Data;
using CarSiteSecond.ViewModels;

namespace CarSiteSecond.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Purchase(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IRepo repo = Factory.Create();
                CarRequest carRequest = new CarRequest();
                Car car = new Car();
                car.id = (int)id;
                carRequest.Cars.Add(car);
                CarResponse carResponse = new CarResponse();
                carResponse.Cars.Add(repo.GetCarsOne(carRequest).Cars.FirstOrDefault());
                if (carResponse.Cars.FirstOrDefault() == null || carResponse.Cars.FirstOrDefault().id == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    PurchaseViewModel sale = new PurchaseViewModel();
                    MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                    ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                    InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                    ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                    sale.carId = carResponse.Cars.FirstOrDefault().id;
                    sale.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    sale.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
                    sale.Model = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
                    sale.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                    sale.MSRP = carResponse.Cars.FirstOrDefault().MSRP;
                    sale.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                    sale.SalePrice = carResponse.Cars.FirstOrDefault().SalePrice;
                    sale.Trans = carResponse.Cars.FirstOrDefault().Transmission;
                    sale.VIN = carResponse.Cars.FirstOrDefault().VIN;
                    sale.Year = carResponse.Cars.FirstOrDefault().Year;
                    sale.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                    sale.Color = colorResponse.Colors.FirstOrDefault(c => c.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;
                    sale.Description = carResponse.Cars.FirstOrDefault().Description;
                    PurchaseTypeRequest purchaseTypeRequest = new PurchaseTypeRequest();
                    PurchaseTypeResponse purchaseTypeResponse = repo.GetPurchaseTypesAll(purchaseTypeRequest);
                    foreach (PurchaseType p in purchaseTypeResponse.PurchaseTypes)
                    {
                        sale.PurchaseTypes.Add(p.Type);
                    }
                    return View(sale);
                }
            }
        }

        [HttpPost]

        public ActionResult PurchaseSave(PurchaseViewModel sale)
        {
            if (sale.SaleId != "")
            {
                IRepo repo = Factory.Create();
                SaleRequest saleRequest = new SaleRequest();
                Sale sales = new Sale();
                sales.CarID = sale.carId;
                sales.City = sale.City;
                sales.Email = sale.Email;
                sales.Name = sale.CusName;
                sales.Phone = sale.Phone;
                sales.PurchasePrice = sale.PurchasePrice;
                PurchaseTypeRequest purchaseTypeRequest = new PurchaseTypeRequest();
                PurchaseTypeResponse purchaseTypeResponse = repo.GetPurchaseTypesAll(purchaseTypeRequest);
                sales.PurchaseType = purchaseTypeResponse.PurchaseTypes.FirstOrDefault().id;
                sales.State = sale.State;
                sales.Street1 = sale.Street1;
                sales.Street2 = sale.Street2;
                UserRequest userRequest = new UserRequest();
                UserResponse userResponse = new UserResponse();
                userResponse = repo.GetUsersAll(userRequest);
                sales.UserID = userResponse.Users.FirstOrDefault(x => x.UserName == sale.SaleId).Id;
                sales.Zip = sale.Zip;
                saleRequest.Sales.Add(sales);
                repo.CreateSalesOne(saleRequest);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}