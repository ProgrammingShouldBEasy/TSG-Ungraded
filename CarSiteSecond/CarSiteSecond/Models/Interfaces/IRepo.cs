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
        //What CRUD methods should I have?
        //CRUD
        CarResponse GetCarsAll(CarRequest carRequest);
        CarResponse GetCarsOne(CarRequest carRequest);
        CarResponse CreateCarsOne(CarRequest carRequest);
        CarResponse UpdateCarsOne(CarRequest carRequest);
        CarResponse DeleteCarsOne(CarRequest carRequest);

        //CRUD
        SpecialResponse GetSpecialsAll(SpecialRequest specialRequest);
        SpecialResponse GetSpecialsOne(SpecialRequest specialRequest);
        SpecialResponse CreateSpecialsOne(SpecialRequest specialRequest);
        SpecialResponse UpdateSpecialsOne(SpecialRequest specialRequest);
        SpecialResponse DeleteSpecialsOne(SpecialRequest specialRequest);

        //C
        ContactResponse CreateContactsOne(ContactRequest contactRequest);

        //CR
        MakeResponse GetMakesAll(MakeRequest makeRequest); 
        MakeResponse GetMakesOne(MakeRequest makeRequest);
        MakeResponse CreateMakesOne(MakeRequest makeRequest);

        //CR
        ModelResponse GetModelsAll(ModelRequest modelRequest); 
        ModelResponse GetModelsOne(ModelRequest modelRequest);
        ModelResponse CreateModelsOne(ModelRequest modelRequest);

        //CR
        SaleResponse GetSalesAll(SaleRequest saleRequest); 
        SaleResponse GetSalesOne(SaleRequest saleRequest);
        SaleResponse CreateSalesOne(SaleRequest saleRequest);

        //CRU
        UserResponse GetUsersAll(UserRequest userRequest); 
        UserResponse GetUsersOne(UserRequest userRequest);
        UserResponse CreateUsersOne(UserRequest userRequest);
        UserResponse UpdateUsersOne(UserRequest userRequest);
    }
}