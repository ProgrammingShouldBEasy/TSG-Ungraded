using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.ViewModels;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Data.Repos;
using CarSiteSecond.Data;

namespace CarSiteSecond.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            IRepo repo = Factory.Create();
            CarResponse carResponse = repo.GetCarsAll(new CarRequest());
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            SpecialResponse specialResponse = repo.GetSpecialsAll(new SpecialRequest());
            foreach(var c in carResponse.Cars)
            {
                if (c.Featured == true)
                {
                    model.HMCVMs.Add(new HomeCarViewModel(c.id, c.PictureSrc, c.Year,
                        //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                        makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).MakeID).MakeName, 
                        modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).ModelName, c.SalePrice));
                }
            }
            foreach(var s in specialResponse.Specials)
            {
                model.Specials.Add(s);
            }
            return View(model);
        }

        public ActionResult Specials()
        {
            IRepo repo = Factory.Create();

            return View(repo.GetSpecialsAll(new SpecialRequest()));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            ViewBag.Message = "Your contact page.";
            IRepo repo = Factory.Create();
            ContactRequest contactRequest = new ContactRequest();
            contactRequest.Contacts.Add(contact);
            repo.CreateContactsOne(contactRequest);
            return RedirectToAction("Index");
        }
    }
}