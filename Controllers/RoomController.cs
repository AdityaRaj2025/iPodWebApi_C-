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
    public class RoomController : ApiController
    {
        SqlConnection conn;
        public IEnumerable<Room> GetRoomStatus()
        {
            List<Room> roomStatus = new List<Room>();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand("spGetRoomStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Room mc = new Room();
                mc.RoomId = Convert.ToInt32(reader["RoomId"]);
                mc.RoomStatus = (bool)reader["RoomStatus"];
                roomStatus.Add(mc);
            }
            conn.Close();
            return roomStatus;
        }
    }
}
