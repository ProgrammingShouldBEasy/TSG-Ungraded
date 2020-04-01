using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.POCOs;
using DVDAPI.Models.Responses;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DVDAPI.Models.Repos
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public ResponseDVDs DeleteDVD(int id)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByID";

                conn.Open();
                cmd.CommandText = "DeleteDVD";

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetAll()
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByDirector(string director)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByDirector";

                cmd.Parameters.AddWithValue("@Name", director);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByID(int id)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByID";

                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByRating(string rating)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByRating";

                cmd.Parameters.AddWithValue("@Rating", rating);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByTitle(string title)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByTitle";

                cmd.Parameters.AddWithValue("@Title", title);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs GetByYear(int year)
        {
            ResponseDVDs response = new ResponseDVDs();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetByYear";

                cmd.Parameters.AddWithValue("@Year", year);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
                        response.DVDs.Add(new DVD((int)dr["DVD ID"], dr["Title"].ToString(), dr["Director"].ToString(), dr["Rating"].ToString(), (int)dr["Release Year"], dr["Notes"].ToString()));
                    }
                }
            }
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs NewDVD(DVD dvd)
        {
            ResponseDVDs response = new ResponseDVDs();
            if (dvd != null && dvd.director != null && dvd.dvdId >= 0 && dvd.rating != null && dvd.releaseYear != null && dvd.title != null)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "NewDVD";

                    cmd.Parameters.AddWithValue("@Title", dvd.title);
                    cmd.Parameters.AddWithValue("@Year", dvd.releaseYear);
                    cmd.Parameters.AddWithValue("@Name", dvd.director);
                    cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                    cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            response.DVDs.Add(dvd);
            return response;
            throw new NotImplementedException();
        }

        public ResponseDVDs UpdateDVD(int id, DVD dvd)
        {
            ResponseDVDs response = new ResponseDVDs();
            if (dvd != null && dvd.director != null && dvd.dvdId >= 0 && dvd.rating != null && dvd.releaseYear != null && dvd.title != null)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateDVD";

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Title", dvd.title);
                    cmd.Parameters.AddWithValue("@Year", dvd.releaseYear);
                    cmd.Parameters.AddWithValue("@Name", dvd.director);
                    cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                    cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            response.DVDs.Add(dvd);
            return response;
            throw new NotImplementedException();
        }
    }
}