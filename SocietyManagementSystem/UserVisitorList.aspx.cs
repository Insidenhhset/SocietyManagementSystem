using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class UserVisitorList : System.Web.UI.Page
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

        public int getFlatId(int userId)
        {
            int flatID = 0;
            string q = $"select * from Allotments where User_id='{userId}'";
            SqlCommand cmd = new SqlCommand(q, conn);
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


        private void LoadVisitors()
        {

            int userId = int.Parse(Session["userId"]?.ToString());
            int flatId = getFlatId(userId);



            string query = @"SELECT v.Visitor_Id, 
                            f.Flat_No, 
                            v.Name, 
                            v.Phone, 
                            v.Person_to_meet, 
                            v.In_datetime, 
                            v.Out_datetime,
                            v.Is_in_out
                     FROM Visitors v 
                     INNER JOIN Flats f ON v.Flat_Id = f.Flat_Id
                     WHERE v.Flat_Id = @FlatId";  // 🔹 Filter by FlatId

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FlatId", flatId);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View") 
            {
                int rowIndex;
                if (int.TryParse(e.CommandArgument.ToString(), out rowIndex) && rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
                {
               
                    if (GridView1.DataKeys[rowIndex] != null)
                    {
                        string visitorId = GridView1.DataKeys[rowIndex].Value.ToString();

                      
                        Response.Redirect($"ViewMyVisitor.aspx?Id={visitorId}");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error: Visitor ID not found.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error: Invalid row selected.');</script>");
                }
            }
        }



    }
}