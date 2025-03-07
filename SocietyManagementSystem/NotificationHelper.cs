using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem
{
    public class NotificationHelper
    {
        SqlConnection conn;
        public NotificationHelper() {

            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        public int GetUnreadNotificationCount(int userId)
        {
            int count = 0;
          
                conn.Open();
                string query = $"SELECT COUNT(*) FROM Notifications WHERE  read_status = 'unread' and User_Id='{userId}'";
                SqlCommand cmd = new SqlCommand(query, conn);
            count = (int)cmd.ExecuteScalar();
                conn.Close();
            return count;
        }

        public DataTable GetNotifications(int userId)
        {
            DataTable dt = new DataTable();

                conn.Open();

            string query = $@"
           SELECT TOP 5 Nofify_Id, message, link, Created_At 
            FROM Notifications 
          WHERE User_Id = '{userId}'
           ORDER BY Created_At DESC";



            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                conn.Close();
           
            return dt;
        }

        public Tuple<string, string, string, string> GetMeetingDetails(int Meetid)
        {
            conn.Open();
            Tuple<string, string, string, string> meetingDetails = null;

            string q = $"exec ManageMeetings @action = 'fetch' , @Meeting_Id='{Meetid}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    meetingDetails = new Tuple<string, string, string, string>(
                        dr["Title"].ToString(),
                        Convert.ToDateTime(dr["Date_time"]).ToString("f"),
                        dr["Location"].ToString(),
                        dr["Agenda"].ToString()
                    );
                }
            }

            conn.Close();
            return meetingDetails;
        }

    }
}