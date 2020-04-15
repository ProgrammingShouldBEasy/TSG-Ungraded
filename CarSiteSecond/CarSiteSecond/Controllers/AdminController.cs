using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
            foreach (Interior a in interiorResponse.Interiors)
            {
                vehicle.Interior.Add(a.InteriorName);
            }
            foreach (Make b in makeResponse.Makes)
            {
                vehicle.Make.Add(b.MakeName);
            }
            foreach (Model c in modelResponse.Models)
            {
                vehicle.Model.Add(c.ModelName);
            }
            foreach (Color d in colorResponse.Colors)
            {
                vehicle.Color.Add(d.ColorName);
            }
            vehicle.Type.Add("New");
            vehicle.Type.Add("Used");
            return View(vehicle);

        }

        //[HttpPost]
        //public ActionResult Upload(VehicleViewModel model)
        //{
        //    IRepo repo = Factory.Create();
        //    Car car = new Car();
        //    CarRequest carRequest = new CarRequest();
        //    CarResponse carResponse = new CarResponse();
        //    repo.GetCarsAll(carRequest);
        //    if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
        //    {
        //        string pictureSrc = "~/Content/Pictures" +
        //            Path.GetFileName("inventory-" + carResponse.Cars.Count());
        //        model.UploadedFile.SaveAs(pictureSrc);
        //        model.PictureSrc = pictureSrc;
        //    }

        //    return View("AddVehicle", model);
        //}

        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel vehicle)
        {
            //Work in an int id
            //put in a selected field and all the list data onto the VehicleViewModel
            //Save Vehicle in add method, pass id to Edit method.
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
            car.SalePrice = vehicle.SalePrice;
            car.Transmission = vehicle.Transmission;
            car.VIN = vehicle.VIN;
            car.Year = vehicle.Year;
            car.Description = vehicle.Description;
            CarResponse carResponse = new CarResponse();
            carResponse = repo.GetCarsAll(carRequest);
            if (vehicle.UploadedFile != null && vehicle.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Pictures/"),
                    Path.GetFileName("inventory-" + carResponse.Cars.Max(x => x.id + 1) + ".jpg"));

                vehicle.UploadedFile.SaveAs(path);
                car.PictureSrc = "~/Content/Pictures/Inventory-" + carResponse.Cars.Max(x => x.id + 1) + ".jpg";
            }
            carRequest.Cars.Add(car);
            repo.CreateCarsOne(carRequest);
            //How do I get the car id it was just added with so I can pass it through to the Edit Vehicle portion?

            carRequest.Cars.Add(car);
            car.id = repo.GetCarsAll(new CarRequest()).Cars.Max(x => x.id);
            carResponse.Cars.Add(repo.GetCarsOne(carRequest).Cars.FirstOrDefault());
            if (carResponse.Cars.FirstOrDefault() == null || carResponse.Cars.FirstOrDefault().id == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("EditGet", new RouteValueDictionary(
                    new { controller = "Admin", action = "EditGet", id = car.id }));
            }
        }

        public ActionResult EditGet(int? id)
        {
            IRepo repo = Factory.Create();
            CarRequest carRequest = new CarRequest();
            Car car = new Car();
            car.id = (int)id;
            carRequest.Cars.Add(car);
            CarResponse carResponse = repo.GetCarsOne(carRequest);
            VehicleViewModel model = new VehicleViewModel();
            model.id = (int)id;
            model.PictureSrc = carResponse.Cars.FirstOrDefault().PictureSrc;
            model.Mileage = carResponse.Cars.FirstOrDefault().Mileage;
            model.MSRP = (int)carResponse.Cars.FirstOrDefault().MSRP;
            model.SalePrice = (int)carResponse.Cars.FirstOrDefault().SalePrice;
            model.Transmission = carResponse.Cars.FirstOrDefault().Transmission;
            model.VIN = carResponse.Cars.FirstOrDefault().VIN;
            model.Year = carResponse.Cars.FirstOrDefault().Year;
            model.Description = carResponse.Cars.FirstOrDefault().Description;
            model.BodyStyle = carResponse.Cars.FirstOrDefault().BodyStyle;
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            foreach (Interior a in interiorResponse.Interiors)
            {
                model.Interior.Add(a.InteriorName);
            }
            foreach (Make b in makeResponse.Makes)
            {
                model.Make.Add(b.MakeName);
            }
            foreach (Model c in modelResponse.Models)
            {
                model.Model.Add(c.ModelName);
            }
            foreach (Color d in colorResponse.Colors)
            {
                model.Color.Add(d.ColorName);
            }
            model.Type.Add("New");
            model.Type.Add("Used");
            model.InteriorSelected = interiorResponse.Interiors.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().InteriorID).InteriorName;
            model.MakeSelected = makeResponse.Makes.FirstOrDefault(x => x.id == modelResponse.Models.FirstOrDefault(y => y.id == carResponse.Cars.FirstOrDefault().ModelID).MakeID).MakeName;
            model.ModelSelected = modelResponse.Models.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ModelID).ModelName;
            if(model.Year >= DateTime.Today.Year)
            {
                model.TypeSelected = "New";
            }
            else
            {
                model.TypeSelected = "Used";
            }
            model.ColorSelected = colorResponse.Colors.FirstOrDefault(x => x.id == carResponse.Cars.FirstOrDefault().ColorID).ColorName;

            //                makeResponse.Makes.FirstOrDefault(y => y.id == modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).MakeID).MakeName, 
            //modelResponse.Models.FirstOrDefault(x => x.id == c.ModelID).ModelName, c.SalePrice));
            return View("EditVehicle", model);
        }

        public ActionResult SaveEdit(VehicleViewModel vehicle)
        {

            IRepo repo = Factory.Create();
            Car car = new Car();
            CarRequest carRequest = new CarRequest();
            car.BodyStyle = vehicle.BodyStyle;
            MakeResponse makeResponse = repo.GetMakesAll(new MakeRequest());
            ModelResponse modelResponse = repo.GetModelsAll(new ModelRequest());
            InteriorResponse interiorResponse = repo.GetInteriorsAll(new InteriorRequest());
            ColorResponse colorResponse = repo.GetColorsAll(new ColorRequest());
            car.id = vehicle.id;
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
            car.Description = vehicle.Description;
            car.Featured = vehicle.Featured;
            CarResponse carResponse = new CarResponse();
            carResponse = repo.GetCarsAll(carRequest);
            if (vehicle.UploadedFile != null && vehicle.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Pictures/"),
                    Path.GetFileName("Inventory-" + vehicle.id + ".jpg"));

                vehicle.UploadedFile.SaveAs(path);
                car.PictureSrc = "~/Content/Pictures/Inventory-" + vehicle.id + ".jpg";
            }
            else
            {
                car.PictureSrc = carResponse.Cars.FirstOrDefault(x => x.id == car.id).PictureSrc;
            }
            carRequest.Cars.Add(car);
            repo.UpdateCarsOne(carRequest);
            vehicle.id = carResponse.Cars.Max(x => x.id);
            //How do I get the car id it was just added with so I can pass it through to the Edit Vehicle portion?
            return RedirectToAction("Index", "Home");
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
            foreach (User u in userResponse.Users)
            {
                UserViewModel user = new UserViewModel();
                user.Email = u.Email;
                //Gets User based on email. Gets UserID/RoleID relationship based on the UserID from the User. Gets RoleName based on the UserID/RoleID relationship to assign Roles to Users.
                user.Role = userRoleResponse.UserRoles.FirstOrDefault(x => x.id == roleResponse.Roles.FirstOrDefault(y => y.UserID == userResponse.Users.FirstOrDefault(z => z.Email == u.Email).Id).RoleID).RoleName;
                //Gets User based on email. Assigns UserID.
                user.id = userResponse.Users.FirstOrDefault(z => z.Email == u.Email).Id;
                model.Add(user);
            }

            return View(model);
        }

        public ActionResult AddUser()
        {
            return View("Register", "Account");
        }

        public ActionResult EditUser(string id)
        {
            return View();
        }

        public ActionResult Makes()
        {
            IRepo repo = Factory.Create();
            MakeRequest makeRequest = new MakeRequest();
            MakeResponse makeResponse = new MakeResponse();
            makeResponse = repo.GetMakesAll(makeRequest);
            UserRequest userRequest = new UserRequest();
            UserResponse userResponse = new UserResponse();
            userResponse = repo.GetUsersAll(userRequest);
            List<MakeViewModel> model = new List<MakeViewModel>();
            foreach (var a in makeResponse.Makes)
            {
                MakeViewModel makeViewModel = new MakeViewModel();
                makeViewModel.DateAdded = a.DateAdded.ToShortDateString();
                makeViewModel.Make = a.MakeName;
                makeViewModel.User = userResponse.Users.FirstOrDefault(x => x.Id == a.UserID).UserName;
                model.Add(makeViewModel);
            }
            return View(model);
        }

        public ActionResult NewMake(Make model)
        {
            IRepo repo = Factory.Create();
            MakeRequest makeRequest = new MakeRequest();

            UserRequest userRequest = new UserRequest();
            UserResponse userResponse = new UserResponse();
            userResponse = repo.GetUsersAll(userRequest);
            model.UserID = userResponse.Users.FirstOrDefault(x => x.UserName == model.UserID).Id;
            makeRequest.Makes.Add(model);
            repo.CreateMakesOne(makeRequest);
            return RedirectToAction("Makes");
        }

        public ActionResult Models()
        {
            IRepo repo = Factory.Create();
            MakeRequest makeRequest = new MakeRequest();
            MakeResponse makeResponse = new MakeResponse();
            makeResponse = repo.GetMakesAll(makeRequest);
            ModelRequest modelRequest = new ModelRequest();
            ModelResponse modelResponse = new ModelResponse();
            modelResponse = repo.GetModelsAll(modelRequest);
            UserRequest userRequest = new UserRequest();
            UserResponse userResponse = new UserResponse();
            userResponse = repo.GetUsersAll(userRequest);
            List<ModelViewModel> model = new List<ModelViewModel>();
            foreach (var a in modelResponse.Models)
            {
                ModelViewModel modelViewModel = new ModelViewModel();
                modelViewModel.DateAdded = a.DateAdded.ToShortDateString();
                modelViewModel.Make = makeResponse.Makes.FirstOrDefault(x => x.id == a.MakeID).MakeName;
                modelViewModel.Model = a.ModelName;
                modelViewModel.User = userResponse.Users.FirstOrDefault(x => x.Id == a.UserID).UserName;
                foreach (var l in makeResponse.Makes)
                {
                    modelViewModel.MakesList.Add(l.MakeName);
                }
                model.Add(modelViewModel);
            }
            return View(model);
        }

        public ActionResult NewModel(ModelForView model)
        {
            IRepo repo = Factory.Create();
            ModelRequest modelRequest = new ModelRequest();
            UserRequest userRequest = new UserRequest();
            UserResponse userResponse = new UserResponse();
            userResponse = repo.GetUsersAll(userRequest);
            MakeRequest makeRequest = new MakeRequest();
            MakeResponse makeResponse = repo.GetMakesAll(makeRequest);
            Model modelToAdd = new Model();
            modelToAdd.ModelName = model.ModelName;
            modelToAdd.UserID = userResponse.Users.FirstOrDefault(x => x.UserName == model.UserID).Id;
            modelToAdd.MakeID = makeResponse.Makes.FirstOrDefault(x => x.MakeName == model.MakeName).id;
            modelRequest.Models.Add(modelToAdd);
            repo.CreateModelsOne(modelRequest);
            return RedirectToAction("Models");
        }

        public ActionResult Specials()
        {
            IRepo repo = Factory.Create();
            SpecialRequest specialRequest = new SpecialRequest();
            SpecialResponse specialResponse = repo.GetSpecialsAll(specialRequest);
            SpecialsViewModel model = new SpecialsViewModel();
            foreach (Special s in specialResponse.Specials)
            {
                model.Specials.Add(s);
            }
            return View(model);
        }

        public ActionResult AddSpecial(SpecialsViewModel model)
        {
            IRepo repo = Factory.Create();
            SpecialRequest specialRequest = new SpecialRequest();
            Special newSpecial = new Special();
            newSpecial.Text = model.Description;
            newSpecial.Title = model.Title;
            specialRequest.Specials.Add(newSpecial);
            repo.CreateSpecialsOne(specialRequest);
            return RedirectToAction("Specials");
        }

        public ActionResult DeleteSpecial(int? id)
        {
            IRepo repo = Factory.Create();
            SpecialRequest specialRequest = new SpecialRequest();
            Special deleteSpecial = new Special();
            deleteSpecial.id = (int)id;
            specialRequest.Specials.Add(deleteSpecial);
            repo.DeleteSpecialsOne(specialRequest);
            return RedirectToAction("Specials");
        }

        public ActionResult ChangePassword()
        {
            return RedirectToAction("ForgotPassword", "Account");
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult InventoryReport()
        {
            IRepo repo = Factory.Create();
            List<InventoryViewModel> model = new List<InventoryViewModel>();
            model = repo.GetInventoryReport();
            return View(model);
        }

        public ActionResult SalesReport()
        {
            IRepo repo = Factory.Create();
            List<SalesReportViewModel> model = new List<SalesReportViewModel>();
            model = repo.GetSalesReport();
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            IRepo repo = Factory.Create();
            Car car = new Car();
            car.id = (int)id;
            CarRequest carRequest = new CarRequest();
            carRequest.Cars.Add(car);
            if (repo.GetCarsOne(carRequest).Cars.FirstOrDefault().Year >= 1900)
            {
                repo.DeleteCarsOne(carRequest);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}