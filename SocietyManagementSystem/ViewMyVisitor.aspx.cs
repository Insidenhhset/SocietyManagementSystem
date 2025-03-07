using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class ViewMyVisitor : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            if (!IsPostBack)
            {
                LoadVisitors();

            }
        }

        private int GetFlatId(int userId)
        {
            int flatID = 0;
           
            
                string query = "SELECT Flat_Id FROM Allotments WHERE User_id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        flatID = Convert.ToInt32(result);
                    }
                }
            
            return flatID;
        }

        private void LoadVisitors()
        {
            int userId = Convert.ToInt32(Session["userId"]);
            int flatId = GetFlatId(userId);

            string query = @"SELECT v.Visitor_Id, 
                            f.Flat_No, 
                            v.Name, 
                            v.Phone, 
                            v.Address,
                            v.Person_to_meet, 
                            v.Reason,
                            v.In_datetime, 
                            v.Out_remark,
                            v.Out_datetime,
                            v.Is_in_out
                     FROM Visitors v 
                     INNER JOIN Flats f ON v.Flat_Id = f.Flat_Id
                     WHERE v.Flat_Id = @FlatId";


            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@FlatId", flatId);

                   SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Label1.Text = reader["Flat_No"].ToString();
                    Label2.Text = reader["Name"].ToString();
                    Label3.Text = reader["Phone"].ToString();
                    Label4.Text = reader["Address"].ToString();
                    Label5.Text = reader["Person_to_meet"].ToString();
                    Label6.Text = reader["Reason"].ToString();
                    Label7.Text = reader["In_datetime"].ToString();
                    Label8.Text = reader["Out_remark"].ToString();
                    Label9.Text = reader["Out_datetime"].ToString();
                    Label10.Text = reader["Is_in_out"].ToString();
                }
            }


        }

     
    }
}
