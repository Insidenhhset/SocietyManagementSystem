using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class AddCompleint : System.Web.UI.Page
    {

        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            
        }

        public int getFlatId(int userId)
        {
            int flatID = 0;
            string q = $"select * from Allotments where User_id='{userId}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    flatID = int.Parse(dr["Flat_Id"].ToString());
                }
            }
            return flatID; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["userId"]?.ToString());
            int flatId = getFlatId(userId);
            string description = TextBox1.Text;

            string q = $"exec addComplaint {userId}, {flatId}, '{description}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Redirect("UserCompleintList.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}




