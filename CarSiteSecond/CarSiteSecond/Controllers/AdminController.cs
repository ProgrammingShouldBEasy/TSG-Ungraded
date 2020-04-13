using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVehicle(Car car)
        {
            return View(car);
        }

        public ActionResult EditVehicle()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult Makes()
        {
            return View();
        }

        public ActionResult Models()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }
    }
}