using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using CarSiteSecond.ViewModels;

namespace CarSiteSecond.Data.Repos
{
    public class CarSiteRepoQA : IRepo
    {
        List<Car> Cars = new List<Car>();
        List<Contact> Contacts = new List<Contact>();
        List<Make> Makes = new List<Make>();
        List<Model> Models = new List<Model>();
        List<Sale> Sales = new List<Sale>();
        List<Special> Specials = new List<Special>();
        List<User> Users = new List<User>();
        List<Color> Colors = new List<Color>();
        List<PurchaseType> PurchaseTypes = new List<PurchaseType>();
        List<Interior> Interiors = new List<Interior>();
        List<UserRole> UserRoles = new List<UserRole>();
        List<Role> Roles = new List<Role>();

        public CarResponse CreateCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            if (carRequest.Cars.Count == 1 && carRequest.Cars.FirstOrDefault() != null && carRequest.Cars.FirstOrDefault().ModelID > 0 && carRequest.Cars.FirstOrDefault().Year > 1900 && carRequest.Cars.FirstOrDefault().BodyStyle != "" && carRequest.Cars.FirstOrDefault().Transmission != "" && carRequest.Cars.FirstOrDefault().PictureSrc != "" && carRequest.Cars.FirstOrDefault().InteriorID > 0 && carRequest.Cars.FirstOrDefault().Mileage > 0 && carRequest.Cars.FirstOrDefault().VIN != "" && carRequest.Cars.FirstOrDefault().SalePrice > 0 && carRequest.Cars.FirstOrDefault().MSRP > 0 && carRequest.Cars.FirstOrDefault().ColorID > 0)
            {
                Cars.Add(carRequest.Cars.FirstOrDefault());
            }
            response.Cars.Add(carRequest.Cars.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public ContactResponse CreateContactsOne(ContactRequest contactRequest)
        {
            ContactResponse response = new ContactResponse();
            if (contactRequest.Contacts.Count == 1 && contactRequest.Contacts.FirstOrDefault() != null && contactRequest.Contacts.FirstOrDefault().Name != "" && contactRequest.Contacts.FirstOrDefault().Email != "" && contactRequest.Contacts.FirstOrDefault().Phone != "" && contactRequest.Contacts.FirstOrDefault().Message != "")
            {
                Contacts.Add(contactRequest.Contacts.FirstOrDefault());
            }
            response.Contacts.Add(contactRequest.Contacts.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public MakeResponse CreateMakesOne(MakeRequest makeRequest)
        {
            MakeResponse response = new MakeResponse();
            if (makeRequest.Makes.Count == 1 && makeRequest.Makes.FirstOrDefault() != null && makeRequest.Makes.FirstOrDefault().id > 0 && makeRequest.Makes.FirstOrDefault().MakeName != "" && makeRequest.Makes.FirstOrDefault().DateAdded <= DateTime.Now && makeRequest.Makes.Count == 1 && makeRequest.Makes.FirstOrDefault() != null && makeRequest.Makes.FirstOrDefault().id > 0 && makeRequest.Makes.FirstOrDefault().MakeName != "" && makeRequest.Makes.FirstOrDefault().UserID != "")
            {
                Makes.Add(makeRequest.Makes.FirstOrDefault());
            }
            response.Makes.Add(makeRequest.Makes.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public ModelResponse CreateModelsOne(ModelRequest modelRequest)
        {
            ModelResponse response = new ModelResponse();
            if (modelRequest.Models.Count == 1 && modelRequest.Models.FirstOrDefault() != null && modelRequest.Models.FirstOrDefault().ModelName != "" && modelRequest.Models.FirstOrDefault().MakeID > 0 && modelRequest.Models.FirstOrDefault().DateAdded <= DateTime.Now && modelRequest.Models.FirstOrDefault().UserID != "")
            {
                Models.Add(modelRequest.Models.FirstOrDefault());
            }
            response.Models.Add(modelRequest.Models.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse CreateSalesOne(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            if (saleRequest.Sales.Count == 1 && saleRequest.Sales.FirstOrDefault() != null && saleRequest.Sales.FirstOrDefault().PurchaseType > 0 && saleRequest.Sales.FirstOrDefault().Name != "" && saleRequest.Sales.FirstOrDefault().Email != "" && saleRequest.Sales.FirstOrDefault().Street1 != "" && saleRequest.Sales.FirstOrDefault().Street2 != "" && saleRequest.Sales.FirstOrDefault().City != "" && saleRequest.Sales.FirstOrDefault().State != "" && saleRequest.Sales.FirstOrDefault().Zip != "" && saleRequest.Sales.FirstOrDefault().Phone != "" && saleRequest.Sales.FirstOrDefault().CarID > 0 && saleRequest.Sales.FirstOrDefault().UserID != "" && saleRequest.Sales.FirstOrDefault().PurchasePrice < 0)
            {
                Sales.Add(saleRequest.Sales.FirstOrDefault());
            }
            response.Sales.Add(saleRequest.Sales.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse CreateSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            if (specialRequest.Specials.Count == 1 && specialRequest.Specials.FirstOrDefault() != null && specialRequest.Specials.FirstOrDefault().Title != "" && specialRequest.Specials.FirstOrDefault().Text != "")
            {
                Specials.Add(specialRequest.Specials.FirstOrDefault());
            }
            response.Specials.Add(specialRequest.Specials.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public CarResponse DeleteCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            response.Cars.Add(Cars.Where(c => c.id == carRequest.Cars.FirstOrDefault().id).FirstOrDefault());
            Cars.RemoveAll(c => c.id == carRequest.Cars.FirstOrDefault().id);
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse DeleteSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            response.Specials.Add(Specials.Where(s => s.id == specialRequest.Specials.FirstOrDefault().id).FirstOrDefault());
            Specials.RemoveAll(s => s.id == specialRequest.Specials.FirstOrDefault().id);
            return response;
            throw new NotImplementedException();
        }

        public CarResponse GetCarsAll(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            foreach(Car c in Cars)
            {
                response.Cars.Add(c);
            }
            return response;
            throw new NotImplementedException();
        }

        public CarResponse GetCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            response.Cars.Add(Cars.Where(c => c.id == carRequest.Cars.FirstOrDefault().id).FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public ColorResponse GetColorsAll(ColorRequest colorRequest)
        {
            ColorResponse response = new ColorResponse();
            foreach (Color c in Colors)
            {
                response.Colors.Add(c);
            }
            return response;
            throw new NotImplementedException();
        }

        public InteriorResponse GetInteriorsAll(InteriorRequest interiorRequest)
        {
            InteriorResponse response = new InteriorResponse();
            foreach (Interior i in Interiors)
            {
                response.Interiors.Add(i);
            }
            return response;
            throw new NotImplementedException();
        }

        public List<InventoryViewModel> GetInventoryReport()
        {
            throw new NotImplementedException();
        }

        public MakeResponse GetMakesAll(MakeRequest makeRequest)
        {
            MakeResponse response = new MakeResponse();
            foreach (Make m in Makes)
            {
                response.Makes.Add(m);
            }
            return response;
            throw new NotImplementedException();
        }

        public MakeResponse GetMakesOne(MakeRequest makeRequest)
        {
            MakeResponse response = new MakeResponse();
            response.Makes.Add(Makes.Where(m => m.id == makeRequest.Makes.FirstOrDefault().id).FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public ModelResponse GetModelsAll(ModelRequest modelRequest)
        {
            ModelResponse response = new ModelResponse();
            foreach (Model m in Models)
            {
                response.Models.Add(m);
            }
            return response;
            throw new NotImplementedException();
        }

        public ModelResponse GetModelsOne(ModelRequest modelRequest)
        {
            ModelResponse response = new ModelResponse();
            response.Models.Add(Models.Where(m => m.id == modelRequest.Models.FirstOrDefault().id).FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public PurchaseTypeResponse GetPurchaseTypesAll(PurchaseTypeRequest PurchaseTypeRequest)
        {
            PurchaseTypeResponse response = new PurchaseTypeResponse();
            foreach (PurchaseType p in PurchaseTypes)
            {
                response.PurchaseTypes.Add(p);
            }
            return response;
            throw new NotImplementedException();
        }

        public RoleResponse GetRolesAll(RoleRequest RoleRequest)
        {
            RoleResponse response = new RoleResponse();
            foreach (Role u in Roles)
            {
                response.Roles.Add(u);
            }
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse GetSalesAll(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            foreach (Sale s in Sales)
            {
                response.Sales.Add(s);
            }
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse GetSalesOne(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            response.Sales.Add(Sales.Where(s => s.id == saleRequest.Sales.FirstOrDefault().id).FirstOrDefault());

            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse GetSpecialsAll(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            foreach (Special s in Specials)
            {
                response.Specials.Add(s);
            }
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse GetSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            response.Specials.Add(Specials.Where(s => s.id == specialRequest.Specials.FirstOrDefault().id).FirstOrDefault());

            return response;
            throw new NotImplementedException();
        }

        public UserRoleResponse GetUserRolesAll(UserRoleRequest UserRoleRequest)
        {
            UserRoleResponse response = new UserRoleResponse();
            foreach (UserRole u in UserRoles)
            {
                response.UserRoles.Add(u);
            }
            return response;
            throw new NotImplementedException();
        }

        public UserResponse GetUsersAll(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();
            foreach (User u in Users)
            {
                response.Users.Add(u);
            }
            return response;
            throw new NotImplementedException();
        }

        public CarResponse UpdateCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            if (carRequest.Cars.Count == 1 && carRequest.Cars.FirstOrDefault() != null && carRequest.Cars.FirstOrDefault().ModelID > 0 && carRequest.Cars.FirstOrDefault().Year > 1900 && carRequest.Cars.FirstOrDefault().BodyStyle != "" && carRequest.Cars.FirstOrDefault().Transmission != "" && carRequest.Cars.FirstOrDefault().PictureSrc != "" && carRequest.Cars.FirstOrDefault().InteriorID > 0 && carRequest.Cars.FirstOrDefault().Mileage > 0 && carRequest.Cars.FirstOrDefault().VIN != "" && carRequest.Cars.FirstOrDefault().SalePrice > 0 && carRequest.Cars.FirstOrDefault().MSRP > 0 && carRequest.Cars.FirstOrDefault().ColorID > 0)
            {
                Cars.RemoveAt(carRequest.Cars.FirstOrDefault().id);
                Cars.Add(carRequest.Cars.FirstOrDefault());
            }
            response.Cars.Add(carRequest.Cars.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse UpdateSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            if (specialRequest.Specials.Count == 1 && specialRequest.Specials.FirstOrDefault() != null && specialRequest.Specials.FirstOrDefault().Title != "" && specialRequest.Specials.FirstOrDefault().Text != "")

            {
                Specials.RemoveAt(specialRequest.Specials.FirstOrDefault().id);
                Specials.Add(specialRequest.Specials.FirstOrDefault());
            }
            response.Specials.Add(specialRequest.Specials.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }
    }
}