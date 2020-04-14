using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSiteSecond.Data;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.ViewModels;

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
            IRepo repo = Factory.Create();
            VehicleViewModel vehicle = new VehicleViewModel();
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            foreach (Interior i in interiorResponse.Interiors)
            {
                vehicle.Interior.Add(i.InteriorName);
            }
            foreach (Make m in makeResponse.Makes)
            {
                vehicle.Interior.Add(m.MakeName);
            }
            foreach (Model m in modelResponse.Models)
            {
                vehicle.Model.Add(m.ModelName);
            }
            foreach (Color c in colorResponse.Colors)
            {
                vehicle.Color.Add(c.ColorName);
            }
            return View(vehicle);

        }

        [HttpPost]
        public ActionResult Upload(VehicleViewModel model)
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            CarResponse carResponse = new CarResponse();
            repo.GetCarsAll(carRequest);
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Data/Pictures"),
                    Path.GetFileName("inventory-" + carResponse.Cars.Count()));

                model.UploadedFile.SaveAs(path);
                model.PictureSrc = path;
            }

            return View("AddVehicle", model);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel vehicle)
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            car.BodyStyle = vehicle.BodyStyle;
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            car.ColorID = colorResponse.Colors.FirstOrDefault(x => x.ColorName == vehicle.Color.FirstOrDefault()).id;
            car.InteriorID = interiorResponse.Interiors.FirstOrDefault(x => x.InteriorName == vehicle.Interior.FirstOrDefault()).id;
            car.Mileage = vehicle.Mileage;
            car.ModelID = modelResponse.Models.FirstOrDefault(x => x.ModelName == vehicle.Model.FirstOrDefault()).id;
            car.MSRP = vehicle.MSRP;
            car.PictureSrc = vehicle.PictureSrc;
            car.SalePrice = vehicle.SalePrice;
            car.Transmission = vehicle.Transmission;
            car.VIN = vehicle.VIN;
            car.Year = vehicle.Year;
            CarResponse carResponse = new CarResponse();
            repo.GetCarsAll(carRequest);
            if (vehicle.UploadedFile != null && vehicle.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Data/Pictures"),
                    Path.GetFileName("inventory-" + carResponse.Cars.Count()));

                vehicle.UploadedFile.SaveAs(path);
                vehicle.PictureSrc = path;
            }
            carRequest.Cars.Add(car);
            repo.CreateCarsOne(carRequest);
            return RedirectToAction("Index","Home");
        }

        public ActionResult EditVehicle(int? id)
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
                    VehicleViewModel vehicle = new VehicleViewModel();
                    MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
                    ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
                    InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
                    ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
                    vehicle.id = carResponse.Cars.FirstOrDefault().id;
                    foreach (Interior i in interiorResponse.Interiors)
                    {
                        vehicle.Interior.Add(i.InteriorName);
                    }
                    foreach (Make m in makeResponse.Makes)
                    {
                        vehicle.Interior.Add(m.MakeName);
                    }
                    foreach (Model m in modelResponse.Models)
                    {
                        vehicle.Model.Add(m.ModelName);
                    }
                    foreach (Color c in colorResponse.Colors)
                    {
                        vehicle.Color.Add(c.ColorName);
                    }
                    //Gets the MakeID by checking the ModelID of the car against the Models table, then gets the Make according to the MakeID, and outputs the MakeName
                    vehicle.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
                    vehicle.MSRP = (int)carResponse.Cars.FirstOrDefault().MSRP;
                    vehicle.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
                    vehicle.SalePrice = (int)carResponse.Cars.FirstOrDefault().SalePrice;
                    vehicle.Transmission = carResponse.Cars.FirstOrDefault().Transmission;
                    vehicle.VIN = carResponse.Cars.FirstOrDefault().VIN;
                    vehicle.Year = carResponse.Cars.FirstOrDefault().Year;
                    vehicle.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
                    vehicle.Description = carResponse.Cars.FirstOrDefault().Description;
                    return View(vehicle);
                }
            }
        }

        public ActionResult Users()
        {
            IRepo repo = Factory.Create();
            UserRoleRequest userRoleRequest = new UserRoleRequest();
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            userRoleResponse = repo.GetUserRolesAll(userRoleRequest);
            RoleRequest roleRequest = new RoleRequest();
            RoleResponse roleResponse = new RoleResponse();
            roleResponse = repo.GetRolesAll(roleRequest);
            UserRequest userRequest = new UserRequest();
            UserResponse userResponse = new UserResponse();
            userResponse = repo.GetUsersAll(userRequest);
            List<UserViewModel> model = new List<UserViewModel>();
            foreach(User u in userResponse.Users)
            {
                UserViewModel user = new UserViewModel();
                user.Email = u.Email;
                var names = u.UserName.Split(' ');
                user.FirstName = names[0];
                user.LastName = names[1];
                //Gets User based on email. Gets UserID/RoleID relationship based on the UserID from the User. Gets RoleName based on the UserID/RoleID relationship to assign Roles to Users.
                user.Role = userRoleRequest.UserRoles.FirstOrDefault(x => x.id == roleRequest.Roles.FirstOrDefault(y => y.UserID == userResponse.Users.FirstOrDefault(z => z.Email == u.Email).Id).UserID).RoleName;
                //Gets User based on email. Assigns UserID.
                user.id = userResponse.Users.FirstOrDefault(z => z.Email == u.Email).Id;
                model.Add(user);
            }

            return View(model);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult EditUser(string id)
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