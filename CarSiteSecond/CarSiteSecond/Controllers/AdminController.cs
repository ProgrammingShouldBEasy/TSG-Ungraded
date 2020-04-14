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
                string path = Path.Combine(Server.MapPath("~/Content/Pictures"),
                    Path.GetFileName("inventory-" + carResponse.Cars.Count()));

                model.UploadedFile.SaveAs(path);
                model.PictureSrc = path;
            }

            return View("AddVehicle", model);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel vehicle)
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
            car.Description = vehicle.Description;
            CarResponse carResponse = new CarResponse();
            carResponse = repo.GetCarsAll(carRequest);
            if (vehicle.UploadedFile != null && vehicle.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Pictures"),
                    Path.GetFileName("inventory-" + carResponse.Cars.Count() + ".jpg"));

                vehicle.UploadedFile.SaveAs(path);
                vehicle.PictureSrc = path;
            }
            carRequest.Cars.Add(car);
            repo.CreateCarsOne(carRequest);
            vehicle.id = carResponse.Cars.Max(x => x.id);
            //How do I get the car id it was just added with so I can pass it through to the Edit Vehicle portion?


            car.id = (int)vehicle.id;
            carRequest.Cars.Add(car);
            carResponse.Cars.Add(repo.GetCarsOne(carRequest).Cars.FirstOrDefault());
            if (carResponse.Cars.FirstOrDefault() == null || carResponse.Cars.FirstOrDefault().id == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
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
                carRequest = new CarRequest();
                carRequest.Cars.Add(car);
                repo.UpdateCarsOne(carRequest);
                return View(vehicle);
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
        foreach (User u in userResponse.Users)
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
        newSpecial.Text = model.Title;
        specialRequest.Specials.Add(newSpecial);
        repo.DeleteSpecialsOne(specialRequest);
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
}
}