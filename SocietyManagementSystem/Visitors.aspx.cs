using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Visitors : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);

            if (!IsPostBack)
            {
                LoadVisitors();
            }
        }




        private void LoadVisitors()
        {
            string query = @"SELECT v.Visitor_Id, 
                            f.Flat_No, 
                            v.Name, 
                            v.Phone, 
                            v.Person_to_meet, 
                            v.In_datetime, 
                            COALESCE(CONVERT(VARCHAR, v.Out_datetime, 120), 'NA') AS Out_datetime,
                            v.Is_in_out
                     FROM Visitors v 
                     INNER JOIN Flats f ON v.Flat_Id = f.Flat_Id";

            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int visitorId = Convert.ToInt32(GridView2.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("EditVisitor.aspx?visitorId=" + visitorId);
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString())) // Check if argument is not empty
            {
                int visitorId;
                if (int.TryParse(e.CommandArgument.ToString(), out visitorId)) // Convert safely
                {
                    if (e.CommandName == "View")
                    {
                        Response.Redirect("ViewVisitor.aspx?visitorId=" + visitorId);
                    }
                    else if (e.CommandName == "Edit")
                    {
                        Response.Redirect("EditVisitor.aspx?visitorId=" + visitorId);
                    }
                    else if (e.CommandName == "DeleteVisitor")
                    {
                        DeleteVisitor(visitorId);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid visitor ID: " + e.CommandArgument.ToString() + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('CommandArgument is empty!');</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Handling RowDeleting event to prevent errors
            int visitorId = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            DeleteVisitor(visitorId);
        }

        private void DeleteVisitor(int visitorId)
        {
            string query = "DELETE FROM Visitors WHERE Visitor_Id = @VisitorId";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VisitorId", visitorId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Visitor deleted successfully!');</script>");
                        LoadVisitors(); // Reload visitors after deletion
                    }
                    else
                    {
                        Response.Write("<script>alert('Error deleting visitor.');</script>");
                    }
                }
            }
        }

    }
}
