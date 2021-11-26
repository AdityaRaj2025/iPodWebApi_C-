using iPodWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iPodWebApi.Controllers
{
    public class MajorCategoryController : ApiController
    {
        SqlConnection conn;
        public IEnumerable<MajorCategory> GetMajorCategoryData()
        {
            List<MajorCategory> majorCategoryData = new List<MajorCategory>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand("spGetMajorCategoryData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MajorCategory mc = new MajorCategory();
                mc.MajorCategoryCode = Convert.ToInt32(reader["MajorCategoryCode"]);
                mc.CategoryName = reader["CategoryName"].ToString();
                majorCategoryData.Add(mc);
            }
            conn.Close();
            return majorCategoryData;
        }     
    }   
}
