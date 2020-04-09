using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;

namespace CarSiteSecond.Models.Interfaces
{
    public interface IRepo
    {
        CarResponse GetCars(CarRequest carRequest);
        ContactResponse GetContacts(ContactRequest contactRequest);
        MakeResponse GetMakes(MakeRequest makeRequest);
        ModelResponse GetModels(ModelRequest modelRequest);
        SaleResponse GetSales(SaleRequest saleRequest);
        UserResponse GetUsers(UserRequest userRequest);
    }
}
