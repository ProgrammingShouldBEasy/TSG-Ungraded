using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Models.DTOs;
using CarSiteSecond.Models.Requests;
using CarSiteSecond.Models.Responses;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CarSiteSecond.Data.Repos
{
    public class CarSiteRepoProduction : IRepo
    {
        public CarResponse CreateCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            if (carRequest.Cars.Count == 1 && carRequest.Cars.FirstOrDefault() != null && carRequest.Cars.FirstOrDefault().ModelID > 0 && carRequest.Cars.FirstOrDefault().Year > 1900 && carRequest.Cars.FirstOrDefault().BodyStyle != "" && carRequest.Cars.FirstOrDefault().Transmission != "" && carRequest.Cars.FirstOrDefault().PictureSrc != "" && carRequest.Cars.FirstOrDefault().InteriorID > 0 && carRequest.Cars.FirstOrDefault().Mileage > 0 && carRequest.Cars.FirstOrDefault().VIN != "" && carRequest.Cars.FirstOrDefault().SalePrice > 0 && carRequest.Cars.FirstOrDefault().MSRP > 0 && carRequest.Cars.FirstOrDefault().ColorID > 0 && carRequest.Cars.FirstOrDefault().Description != "")
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateCarsOne"
                    };

                    cmd.Parameters.AddWithValue("@ModelID", carRequest.Cars.FirstOrDefault().ModelID);
                    cmd.Parameters.AddWithValue("@Year", carRequest.Cars.FirstOrDefault().Year);
                    cmd.Parameters.AddWithValue("@BodyStyle", carRequest.Cars.FirstOrDefault().BodyStyle);
                    cmd.Parameters.AddWithValue("@Transmission", carRequest.Cars.FirstOrDefault().Transmission);
                    cmd.Parameters.AddWithValue("@PictureSrc", carRequest.Cars.FirstOrDefault().PictureSrc);
                    cmd.Parameters.AddWithValue("@InteriorID", carRequest.Cars.FirstOrDefault().InteriorID);
                    cmd.Parameters.AddWithValue("@Mileage", carRequest.Cars.FirstOrDefault().Mileage);
                    cmd.Parameters.AddWithValue("@VIN", carRequest.Cars.FirstOrDefault().VIN);
                    cmd.Parameters.AddWithValue("@SalePrice", carRequest.Cars.FirstOrDefault().SalePrice);
                    cmd.Parameters.AddWithValue("@MSRP", carRequest.Cars.FirstOrDefault().MSRP);
                    cmd.Parameters.AddWithValue("@Featured", carRequest.Cars.FirstOrDefault().Featured);
                    cmd.Parameters.AddWithValue("@ColorID", carRequest.Cars.FirstOrDefault().ColorID);
                    cmd.Parameters.AddWithValue("@Description", carRequest.Cars.FirstOrDefault().Description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateContactsOne"
                    };

                    cmd.Parameters.AddWithValue("@Name", contactRequest.Contacts.FirstOrDefault().Name);
                    cmd.Parameters.AddWithValue("@Email", contactRequest.Contacts.FirstOrDefault().Email);
                    cmd.Parameters.AddWithValue("@Phone", contactRequest.Contacts.FirstOrDefault().Phone);
                    cmd.Parameters.AddWithValue("@Message", contactRequest.Contacts.FirstOrDefault().Message);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateMakesOne"
                    };

                    cmd.Parameters.AddWithValue("@MakeName", makeRequest.Makes.FirstOrDefault().MakeName);
                    cmd.Parameters.AddWithValue("@DateAdded", makeRequest.Makes.FirstOrDefault().DateAdded);
                    cmd.Parameters.AddWithValue("@UserID", makeRequest.Makes.FirstOrDefault().UserID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateModelsOne"
                    };

                    cmd.Parameters.AddWithValue("@ModelName", modelRequest.Models.FirstOrDefault().ModelName);
                    cmd.Parameters.AddWithValue("@MakeID", modelRequest.Models.FirstOrDefault().MakeID);
                    cmd.Parameters.AddWithValue("@DateAdded", modelRequest.Models.FirstOrDefault().DateAdded);
                    cmd.Parameters.AddWithValue("@UserID", modelRequest.Models.FirstOrDefault().UserID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            response.Models.Add(modelRequest.Models.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse CreateSalesOne(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            if (saleRequest.Sales.Count == 1 && saleRequest.Sales.FirstOrDefault() != null && saleRequest.Sales.FirstOrDefault().PurchaseType > 0 && saleRequest.Sales.FirstOrDefault().Name != "" && saleRequest.Sales.FirstOrDefault().Email != "" && saleRequest.Sales.FirstOrDefault().Street1 != "" && saleRequest.Sales.FirstOrDefault().City != "" && saleRequest.Sales.FirstOrDefault().State != "" && saleRequest.Sales.FirstOrDefault().Zip != "" && saleRequest.Sales.FirstOrDefault().Phone != "" && saleRequest.Sales.FirstOrDefault().CarID > 0 && saleRequest.Sales.FirstOrDefault().UserID != "" && saleRequest.Sales.FirstOrDefault().PurchasePrice > 0)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateSalesOne"
                    };

                    cmd.Parameters.AddWithValue("@PurchaseType", saleRequest.Sales.FirstOrDefault().PurchaseType);
                    cmd.Parameters.AddWithValue("@Name", saleRequest.Sales.FirstOrDefault().Name);
                    cmd.Parameters.AddWithValue("@Email", saleRequest.Sales.FirstOrDefault().Email);
                    cmd.Parameters.AddWithValue("@Street1", saleRequest.Sales.FirstOrDefault().Street1);
                    cmd.Parameters.AddWithValue("@Street2", saleRequest.Sales.FirstOrDefault().Street2);
                    cmd.Parameters.AddWithValue("@City", saleRequest.Sales.FirstOrDefault().City);
                    cmd.Parameters.AddWithValue("@State", saleRequest.Sales.FirstOrDefault().State);
                    cmd.Parameters.AddWithValue("@Zip", saleRequest.Sales.FirstOrDefault().Zip);
                    cmd.Parameters.AddWithValue("@Phone", saleRequest.Sales.FirstOrDefault().Phone);
                    cmd.Parameters.AddWithValue("@CarID", saleRequest.Sales.FirstOrDefault().CarID);
                    cmd.Parameters.AddWithValue("@UserID", saleRequest.Sales.FirstOrDefault().UserID);
                    cmd.Parameters.AddWithValue("@PurchasePrice", saleRequest.Sales.FirstOrDefault().PurchasePrice);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "CreateSpecialsOne"
                    };

                    cmd.Parameters.AddWithValue("@Title", specialRequest.Specials.FirstOrDefault().Title);
                    cmd.Parameters.AddWithValue("@Text", specialRequest.Specials.FirstOrDefault().Text);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            response.Specials.Add(specialRequest.Specials.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }

        public CarResponse DeleteCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCarsOne"
                };

                cmd.Parameters.AddWithValue("@ID", carRequest.Cars.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, int modelID, int year, string bodyStyle, string transmission, string pictureSrc, int interiorID, int mileage, string vIN, decimal salePrice, decimal mSRP, bool featured, int colorID)
                        response.Cars.Add(new Car((int)dr["id"], (int)dr["ModelID"], (int)dr["Year"], dr["BodyStyle"].ToString(), dr["Transmission"].ToString(), dr["PictureSrc"].ToString(), (int)dr["InteriorID"], (int)dr["Mileage"], dr["VIN"].ToString(), (decimal)dr["SalePrice"], (decimal)dr["MSRP"], (bool)dr["Featured"], (int)dr["ColorID"], dr["Description"].ToString()));
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteCarsOne"
                };

                conn.Open();

                cmd.Parameters.AddWithValue("@id", carRequest.Cars.FirstOrDefault().id);
                cmd.ExecuteNonQuery();
            }
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse DeleteSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSpecialsOne"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string title, string text)
                        response.Specials.Add(new Special((int)dr["id"], dr["Title"].ToString(), dr["Text"].ToString()));
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteSpecialsOne"
                };

                conn.Open();

                cmd.Parameters.AddWithValue("@id", specialRequest.Specials.FirstOrDefault().id);
                cmd.ExecuteNonQuery();
            }
            return response;
            throw new NotImplementedException();
        }

        public CarResponse GetCarsAll(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCarsAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, int modelID, int year, string bodyStyle, string transmission, string pictureSrc, int interiorID, int mileage, string vIN, decimal salePrice, decimal mSRP, bool featured, int colorID)
                        response.Cars.Add(new Car((int)dr["id"], (int)dr["ModelID"], (int)dr["Year"], dr["BodyStyle"].ToString(), dr["Transmission"].ToString(), dr["PictureSrc"].ToString(), (int)dr["InteriorID"], (int)dr["Mileage"], dr["VIN"].ToString(), (decimal)dr["SalePrice"], (decimal)dr["MSRP"], (bool)dr["Featured"], (int)dr["ColorID"], dr["Description"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public CarResponse GetCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCarsOne",
                };

                cmd.Parameters.AddWithValue("@ID", carRequest.Cars.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, int modelID, int year, string bodyStyle, string transmission, string pictureSrc, int interiorID, int mileage, string vIN, decimal salePrice, decimal mSRP, bool featured, int colorID)
                        response.Cars.Add(new Car((int)dr["id"], (int)dr["ModelID"], (int)dr["Year"], dr["BodyStyle"].ToString(), dr["Transmission"].ToString(), dr["PictureSrc"].ToString(), (int)dr["InteriorID"], (int)dr["Mileage"], dr["VIN"].ToString(), (decimal)dr["SalePrice"], (decimal)dr["MSRP"], (bool)dr["Featured"], (int)dr["ColorID"], dr["Description"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ColorResponse GetColorsAll(ColorRequest colorRequest)
        {
            ColorResponse response = new ColorResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetColorsAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string colorName)
                        response.Colors.Add(new Color((int)dr["id"], dr["ColorName"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public InteriorResponse GetInteriorsAll(InteriorRequest interiorRequest)
        {
            InteriorResponse response = new InteriorResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetInteriorsAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string interiorName)
                        response.Interiors.Add(new Interior((int)dr["id"], dr["InteriorName"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public MakeResponse GetMakesAll(MakeRequest makeRequest)
        {
            MakeResponse response = new MakeResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetMakesAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //int id, string makeName, DateTime dateAdded, string userID
                        response.Makes.Add(new Make((int)dr["id"], dr["MakeName"].ToString(), (DateTime)dr["DateAdded"], dr["UserID"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public MakeResponse GetMakesOne(MakeRequest makeRequest)
        {
            MakeResponse response = new MakeResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetMakesOne"
                };

                cmd.Parameters.AddWithValue("@ID", makeRequest.Makes.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //int id, string makeName, DateTime dateAdded, string userID
                        response.Makes.Add(new Make((int)dr["id"], dr["MakeName"].ToString(), (DateTime)dr["DateAdded"], dr["UserID"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ModelResponse GetModelsAll(ModelRequest modelRequest)
        {
            ModelResponse response = new ModelResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetModelsAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string modelName, int makeID, DateTime dateAdded, string userID)
                        response.Models.Add(new Model((int)dr["id"], dr["ModelName"].ToString(), (int)dr["MakeID"], (DateTime)dr["DateAdded"], dr["UserID"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ModelResponse GetModelsOne(ModelRequest modelRequest)
        {
            ModelResponse response = new ModelResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetModelsOne"
                };

                cmd.Parameters.AddWithValue("@ID", modelRequest.Models.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string modelName, int makeID, DateTime dateAdded, string userID)
                        response.Models.Add(new Model((int)dr["id"], dr["ModelName"].ToString(), (int)dr["MakeID"], (DateTime)dr["DateAdded"], dr["UserID"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public PurchaseTypeResponse GetPurchaseTypesAll(PurchaseTypeRequest PurchaseTypeRequest)
        {
            PurchaseTypeResponse response = new PurchaseTypeResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetPurchaseTypesAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string type)
                        response.PurchaseTypes.Add(new PurchaseType((int)dr["id"], dr["Type"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public RoleResponse GetRolesAll(RoleRequest RoleRequest)
        {
            RoleResponse response = new RoleResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUserRolesAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //int id, string makeName, DateTime dateAdded, string userID
                        response.Roles.Add(new Role(dr["UserId"].ToString(), dr["RoleId"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse GetSalesAll(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSalesAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, int purchaseType, string name, string email, string street1, string street2, string city, string state, string zip, string phone, int carID, string userID, decimal purchasePrice)
                        response.Sales.Add(new Sale((int)dr["id"], (int)dr["PurchaseType"], dr["Name"].ToString(), dr["Email"].ToString(), dr["Street1"].ToString(), dr["Street2"].ToString(), dr["City"].ToString(), dr["State"].ToString(), dr["Zip"].ToString(), dr["Phone"].ToString(), (int)dr["CarID"], dr["UserID"].ToString(), (decimal)dr["PurchasePrice"]));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public SaleResponse GetSalesOne(SaleRequest saleRequest)
        {
            SaleResponse response = new SaleResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSalesOne"
                };

                cmd.Parameters.AddWithValue("@ID", saleRequest.Sales.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, int purchaseType, string name, string email, string street1, string street2, string city, string state, string zip, string phone, int carID, string userID, decimal purchasePrice)
                        response.Sales.Add(new Sale((int)dr["id"], (int)dr["PurchaseType"], dr["Name"].ToString(), dr["Email"].ToString(), dr["Street1"].ToString(), dr["Street2"].ToString(), dr["City"].ToString(), dr["State"].ToString(), dr["Zip"].ToString(), dr["Phone"].ToString(), (int)dr["CarID"], dr["UserID"].ToString(), (decimal)dr["PurchasePrice"]));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse GetSpecialsAll(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSpecialsAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string title, string text)
                        response.Specials.Add(new Special((int)dr["id"], dr["Title"].ToString(), dr["Text"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public SpecialResponse GetSpecialsOne(SpecialRequest specialRequest)
        {
            SpecialResponse response = new SpecialResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSpecialsOne"
                };

                cmd.Parameters.AddWithValue("@ID", specialRequest.Specials.FirstOrDefault().id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int id, string title, string text)
                        response.Specials.Add(new Special((int)dr["id"], dr["Title"].ToString(), dr["Text"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public UserRoleResponse GetUserRolesAll(UserRoleRequest UserRoleRequest)
        {
            UserRoleResponse response = new UserRoleResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetRolesAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //int id, string makeName, DateTime dateAdded, string userID
                        response.UserRoles.Add(new UserRole(dr["Id"].ToString(), dr["Name"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public UserResponse GetUsersAll(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUsersAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(string id, string email, string phoneNumber, string username)
                        response.Users.Add(new User(dr["Id"].ToString(), dr["Email"].ToString(), dr["PhoneNumber"].ToString(), dr["UserName"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public CarResponse UpdateCarsOne(CarRequest carRequest)
        {
            CarResponse response = new CarResponse();
            if (carRequest.Cars.Count == 1 && carRequest.Cars.FirstOrDefault() != null && carRequest.Cars.FirstOrDefault().ModelID > 0 && carRequest.Cars.FirstOrDefault().Year > 1900 && carRequest.Cars.FirstOrDefault().BodyStyle != "" && carRequest.Cars.FirstOrDefault().Transmission != "" && carRequest.Cars.FirstOrDefault().PictureSrc != "" && carRequest.Cars.FirstOrDefault().InteriorID > 0 && carRequest.Cars.FirstOrDefault().Mileage > 0 && carRequest.Cars.FirstOrDefault().VIN != "" && carRequest.Cars.FirstOrDefault().SalePrice > 0 && carRequest.Cars.FirstOrDefault().MSRP > 0 && carRequest.Cars.FirstOrDefault().ColorID > 0 && carRequest.Cars.FirstOrDefault().Description != "")
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "UpdateCarsOne"
                    };

                    cmd.Parameters.AddWithValue("@id", carRequest.Cars.FirstOrDefault().id);
                    cmd.Parameters.AddWithValue("@ModelID", carRequest.Cars.FirstOrDefault().ModelID);
                    cmd.Parameters.AddWithValue("@Year", carRequest.Cars.FirstOrDefault().Year);
                    cmd.Parameters.AddWithValue("@BodyStyle", carRequest.Cars.FirstOrDefault().BodyStyle);
                    cmd.Parameters.AddWithValue("@Transmission", carRequest.Cars.FirstOrDefault().Transmission);
                    cmd.Parameters.AddWithValue("@PictureSrc", carRequest.Cars.FirstOrDefault().PictureSrc);
                    cmd.Parameters.AddWithValue("@InteriorID", carRequest.Cars.FirstOrDefault().InteriorID);
                    cmd.Parameters.AddWithValue("@Mileage", carRequest.Cars.FirstOrDefault().Mileage);
                    cmd.Parameters.AddWithValue("@VIN", carRequest.Cars.FirstOrDefault().VIN);
                    cmd.Parameters.AddWithValue("@SalePrice", carRequest.Cars.FirstOrDefault().SalePrice);
                    cmd.Parameters.AddWithValue("@MSRP", carRequest.Cars.FirstOrDefault().MSRP);
                    cmd.Parameters.AddWithValue("@Featured", carRequest.Cars.FirstOrDefault().Featured);
                    cmd.Parameters.AddWithValue("@ColorID", carRequest.Cars.FirstOrDefault().ColorID);
                    cmd.Parameters.AddWithValue("@Description", carRequest.Cars.FirstOrDefault().Description);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "UpdateSpecialsOne"
                    };

                    cmd.Parameters.AddWithValue("@id", specialRequest.Specials.FirstOrDefault().Title);
                    cmd.Parameters.AddWithValue("@Title", specialRequest.Specials.FirstOrDefault().Title);
                    cmd.Parameters.AddWithValue("@Text", specialRequest.Specials.FirstOrDefault().Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            response.Specials.Add(specialRequest.Specials.FirstOrDefault());
            return response;
            throw new NotImplementedException();
        }
    }
}