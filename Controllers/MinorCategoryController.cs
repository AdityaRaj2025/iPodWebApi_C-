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
    public class MinorCategoryController : ApiController
    {
        SqlConnection conn;
        public IEnumerable<MinorCategory> GetMinorCategoryData()
        {
            List<MinorCategory> minorCategoryData = new List<MinorCategory>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand("spGetMinorCategoryData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MinorCategory mc = new MinorCategory();
                mc.MinorCategoryCode = Convert.ToInt32(reader["MinorCategoryCode"]);
                mc.CategoryName = reader["CategoryName"].ToString();
                minorCategoryData.Add(mc);
            }
            conn.Close();
            return minorCategoryData;
        }
    }
}
