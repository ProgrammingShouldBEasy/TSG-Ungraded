using CarSiteSecond.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Details(Car car)
        {
            return View();
        }
    }
}