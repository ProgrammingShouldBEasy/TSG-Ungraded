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

namespace CarSiteSecond.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Purchase(Sale sale)
        {
            IRepo repo = Factory.Create();
            SaleRequest saleRequest = new SaleRequest();
            if (!ModelState.IsValid)
            {
                return View("Purchase", sale);
            }
            try {
                saleRequest.Sales.Add(sale);
                SaleResponse saleResponse = repo.CreateSalesOne(saleRequest);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to add sale: {ex.Message}");
                return View("Purchase", sale);
            }
            return Redirect("Index");
        }
    }
}