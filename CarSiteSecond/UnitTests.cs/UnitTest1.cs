using CarSiteSecond.Data;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {

        //List<SalesReportViewModel> GetSalesReport(string fromDate, string toDate);
        //Do I need this?

        [TestCase]
        public void GetCarsAllPass()
        {
            IRepo repo = Factory.Create();
            CarRequest carRequest = new CarRequest();
            Car car = new Car();
            car.BodyStyle = "Truck";
            car.ColorID = 1;
            car.Description = "Test";
            car.Featured = false;
            car.id = 1;
            car.InteriorID = 1;
            car.Mileage = 0;
            car.ModelID = 1;
            car.MSRP = 0;
            car.SalePrice = 10;
            car.Transmission = "Automatic";
            car.VIN = "123456789";
            car.Year = 199;
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.CreateCarsOne(carRequest);
            Assert.AreEqual(car.id, repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault().id);
        }

        [TestCase]
        public void GetCarsAllFail()
        {
            IRepo repo = Factory.Create();
            CarRequest carRequest = new CarRequest();
            Car car = new Car();
            car.BodyStyle = "Truck";
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.CreateCarsOne(carRequest);
            Assert.AreNotEqual("SUV", repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault().BodyStyle);
        }

        [TestCase]
        public void GetCarsOnePass()
        {
            IRepo repo = Factory.Create();
            Assert.AreEqual(1, repo.GetCarsAll(new CarRequest()));
        }

        [TestCase]
        public void GetCarsOneFail()
        {
            IRepo repo = Factory.Create();
            Assert.AreNotEqual(1, repo.GetCarsAll(new CarRequest()));
        }

        [TestCase]
        public void UpdateCarsOnePass()
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            car.id = 1;
            car.BodyStyle = "Van";
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.UpdateCarsOne(carRequest);
            Assert.AreEqual(car.BodyStyle, repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault(x => x.id == car.id).BodyStyle);
        }

        [TestCase]
        public void UpdateCarsOneFail()
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            car.id = 1;
            car.BodyStyle = "Van";
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.UpdateCarsOne(carRequest);
            Assert.AreEqual("Truck", repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault(x => x.id == car.id).BodyStyle);
        }

        [TestCase]
        public void DeleteOnePass()
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            car.id = 1;
            car.BodyStyle = "Van";
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            repo.DeleteCarsOne(carRequest);
            Assert.AreEqual(null, repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault());
        }

        [TestCase]
        public void DeleteCarsOneFail()
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            car.id = 1;
            car.BodyStyle = "Van";
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            repo.CreateCarsOne(carRequest);
            carRequest.Cars.FirstOrDefault().id = 2;
            repo.DeleteCarsOne(carRequest);
            Assert.AreEqual(null, repo.GetCarsAll(new CarRequest()).Cars.FirstOrDefault());
        }

        [TestCase]
        public void CreateCarsOnePass()
        {
        }

        [TestCase]
        public void CreateCarsOneFail()
        {

        }

        [TestCase]
        public void DeleteCarsOnePass()
        {
        }

        [TestCase]
        public void DeleteCarseOneFail()
        {

        }

        [TestCase]
        public void GetSpecialsAllPass()
        {
        }

        [TestCase]
        public void GetSpecialsAllFail()
        {

        }

        [TestCase]
        public void GetSpecialsOnePass()
        {
        }

        [TestCase]
        public void GetSpecialsOneFail()
        {

        }

        [TestCase]
        public void CreateSpecialsOnePass()
        {
        }

        [TestCase]
        public void CreateSpecialsOneFail()
        {

        }

        [TestCase]
        public void UpdateSpecialsOnePass()
        {
        }

        [TestCase]
        public void UpdateSpecialsOneFail()
        {

        }

        [TestCase]
        public void DeleteSpecialsOnePass()
        {
        }

        [TestCase]
        public void DeleteSpecialsOneFail()
        {

        }

        [TestCase]
        public void CreateContactsOnePass()
        {
        }

        [TestCase]
        public void CreateContactsOneFail()
        {

        }

        [TestCase]
        public void GetMakesAllPass()
        {
        }

        [TestCase]
        public void GetMakesAllFail()
        {

        }

        [TestCase]
        public void GetMakesOnePass()
        {
        }

        [TestCase]
        public void GetMakesOneFail()
        {

        }

        [TestCase]
        public void CreateMakesOnePass()
        {
        }

        [TestCase]
        public void CreateMakesOneFail()
        {

        }

        [TestCase]
        public void GetModelsAllPass()
        {
        }

        [TestCase]
        public void GetModelsAllFail()
        {

        }

        [TestCase]
        public void GetModelsOnePass()
        {
        }

        [TestCase]
        public void GetModelsOneFail()
        {

        }

        [TestCase]
        public void CreateModelsOnePass()
        {
        }

        [TestCase]
        public void CreateModelsOneFail()
        {

        }

        [TestCase]
        public void GetSalesAllPass()
        {
        }

        [TestCase]
        public void GetSalesAllFail()
        {

        }

        [TestCase]
        public void GetSalesOnePass()
        {
        }

        [TestCase]
        public void GetSalesOneFail()
        {

        }

        [TestCase]
        public void CreateSalesOnePass()
        {
        }

        [TestCase]
        public void CreateSalesOneFail()
        {

        }

        [TestCase]
        public void GetUsersAllPass()
        {
        }

        [TestCase]
        public void GetUsersOneFail()
        {

        }

        [TestCase]
        public void GetColorsAllPass()
        {
        }

        [TestCase]
        public void GetColorsAllFail()
        {

        }

        [TestCase]
        public void GetInteriorsAllPass()
        {
        }

        [TestCase]
        public void GetInteriorsAllFail()
        {

        }

        [TestCase]
        public void GetPurchaseTypesAllPass()
        {
        }

        [TestCase]
        public void GetPurchaseTypesAllFail()
        {

        }

        [TestCase]
        public void GetUsersRoleAllPass()
        {
        }

        [TestCase]
        public void GetUsersRoleAllFail()
        {

        }

        [TestCase]
        public void GetRoleAllPass()
        {
        }

        [TestCase]
        public void GetRoleAllFail()
        {

        }

        [TestCase]
        public void GetInventoryReportPass()
        {

        }

        [TestCase]
        public void GetInventoryReportFail()
        {

        }

        [TestCase]
        public void GetSalesReportPass()
        {
        }

        [TestCase]
        public void GetSalesReportFail()
        {

        }

        //[TestCase]
        //public void GetInventoryReportPass()
        //{
        //    IRepo repo = Factory.Create();
        //}

        //[TestCase]
        //public void GetInventoryReportFail()
        //{

        //}
    }
}