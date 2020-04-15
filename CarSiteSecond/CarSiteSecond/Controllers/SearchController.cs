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
            CarRequest carRequest = new CarRequest();
            CarResponse carResponse = repo.GetCarsAll(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            foreach (Car a in carResponse.Cars)
            {
                CarViewModel model = new CarViewModel();
                if (a.Mileage <= 1000)
                {
                    model.id = a.id;
                    model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == a.InteriorID).InteriorName;
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).MakeID).MakeName;
                    model.Model = modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).ModelName;
                    model.Mileage = a.Mileage;
                    model.MSRP = a.MSRP;
                    model.PictureSrc = "../" + a.PictureSrc.Split(new string[] { "~" }, StringSplitOptions.None)[1];
                    model.SalePrice = a.SalePrice;
                    model.Trans = a.Transmission;
                    model.VIN = a.VIN;
                    model.Year = a.Year;
                    model.BodyStyle = a.BodyStyle;
                    model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == a.ColorID).ColorName;
                    model.Description = a.Description;
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Inventory/Used/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsed()
        {
            CarRequest carRequest = new CarRequest();
            CarResponse carResponse = repo.GetCarsAll(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
            foreach (Car a in carResponse.Cars)
            {
                if (a.Mileage > 1000)
                {
                    CarViewModel model = new CarViewModel();

                    model.id = a.id;
                    model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == a.InteriorID).InteriorName;
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).MakeID).MakeName;
                    model.Model = modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).ModelName;
                    model.Mileage = a.Mileage;
                    model.MSRP = a.MSRP;
                    model.PictureSrc = "../" + a.PictureSrc.Split(new string[] { "~" }, StringSplitOptions.None)[1];
                    model.SalePrice = a.SalePrice;
                    model.Trans = a.Transmission;
                    model.VIN = a.VIN;
                    model.Year = a.Year;
                    model.BodyStyle = a.BodyStyle;
                    model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == a.ColorID).ColorName;
                    model.Description = a.Description;
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Sales/Index/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSales()
        {

            CarRequest carRequest = new CarRequest();
            CarResponse carResponse = repo.GetCarsAll(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
            foreach (Car a in carResponse.Cars)
            {

                if (saleResponse.Sales.FirstOrDefault(x => x.CarID == a.id) == null)
                {
                    CarViewModel model = new CarViewModel();

                    model.id = a.id;
                    model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == a.InteriorID).InteriorName;
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).MakeID).MakeName;
                    model.Model = modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).ModelName;
                    model.Mileage = a.Mileage;
                    model.MSRP = a.MSRP;
                    model.PictureSrc = "../" + a.PictureSrc.Split(new string[] { "~" }, StringSplitOptions.None)[1];
                    model.SalePrice = a.SalePrice;
                    model.Trans = a.Transmission;
                    model.VIN = a.VIN;
                    model.Year = a.Year;
                    model.BodyStyle = a.BodyStyle;
                    model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == a.ColorID).ColorName;
                    model.Description = a.Description;
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Admin/Vehicles/Get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesAdmin()
        {

            CarRequest carRequest = new CarRequest();
            CarResponse carResponse = repo.GetCarsAll(carRequest);
            List<CarViewModel> list = new List<CarViewModel>();
            SaleResponse saleResponse = repo.GetSalesAll(new SaleRequest());
            foreach (Car a in carResponse.Cars)
            {

                if (saleResponse.Sales.FirstOrDefault(x => x.CarID == a.id) == null)
                {
                    CarViewModel model = new CarViewModel();
                    MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                    ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                    InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                    ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());

                    model.id = a.id;
                    model.Interior = interiorResponse.Interiors.FirstOrDefault(i => i.id == a.InteriorID).InteriorName;
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    model.Make = makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).MakeID).MakeName;
                    model.Model = modelResponse.Models.FirstOrDefault(x => x.id == a.ModelID).ModelName;
                    model.Mileage = a.Mileage;
                    model.MSRP = a.MSRP;
                    model.PictureSrc = "../" + a.PictureSrc.Split(new string[] { "~" }, StringSplitOptions.None)[1];
                    model.SalePrice = a.SalePrice;
                    model.Trans = a.Transmission;
                    model.VIN = a.VIN;
                    model.Year = a.Year;
                    model.BodyStyle = a.BodyStyle;
                    model.Color = colorResponse.Colors.FirstOrDefault(c => c.id == a.ColorID).ColorName;
                    model.Description = a.Description;
                    list.Add(model);
                }
            }
            return Ok(list);
        }

        [Route("Reports/Sales/{fromDate}/{toDate}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReports(string fromDate, string toDate)
        {
            List<SalesReportViewModel> response = new List<SalesReportViewModel>();
            if (!DateTime.TryParse((String.Format("{0:yyyy-MM-dd}", fromDate)), out DateTime local))
            {
                fromDate = "1753-01-01";
            }
            if (!DateTime.TryParse((String.Format("{0:yyyy-MM-dd}", toDate)), out DateTime local2))
            {
                toDate = String.Format("{0:yyyy-MM-dd}", DateTime.Today.ToShortDateString());
            }
            response = repo.GetSalesReport(fromDate, toDate);
            return Ok(response);
        }
    }
}

