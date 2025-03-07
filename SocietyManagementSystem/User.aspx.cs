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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            if (!IsPostBack)
            {

            
                int sessionStatus = SessionHelper.CheckSession(HttpContext.Current);

                if (sessionStatus == 1) // Admin
                {
                    return;
                }
                else if (sessionStatus == 0) // User
                {
                    if (Session["username"] != null)
                    {
                        lblUsername.Text = Session["username"].ToString();
                        LoadDashboardData();
                    }
                    return;
                }

            }
        }


        private void LoadDashboardData()
        {
         
            // Get UserID from session
            int userId = Convert.ToInt32(Session["userId"]);  // Assuming UserID is stored in session
            int flatId = Convert.ToInt32(Session["flatId"]);
            total_no_flats.Text = GetCounts("SELECT COUNT(*) FROM Flats WHERE Flat_Id = @Flat_Id", flatId).ToString();
           total_no_bill.Text = GetCounts("SELECT COUNT(*) FROM Bills WHERE Flat_Id = @Flat_Id", flatId).ToString();
            total_no_allotment.Text = GetCount("SELECT COUNT(*) FROM Allotments WHERE User_Id = @User_Id", userId).ToString();
            total_no_in_process_complaint.Text = GetCounts("SELECT COUNT(*) FROM Complaints WHERE Status = 'In Progress' AND Flat_Id = @Flat_Id", flatId).ToString();
            total_no_visitor.Text = GetCounts("SELECT COUNT(*) FROM Visitors WHERE Flat_Id = @Flat_Id", flatId).ToString();
            total_no_unresolved_comp.Text = GetCounts("SELECT COUNT(*) FROM Complaints WHERE Status = 'Unresolved' AND Flat_Id = @Flat_Id", flatId).ToString();
            total_no_resolve_comp.Text = GetCounts("SELECT COUNT(*) FROM Complaints WHERE Status = 'Resolved' AND Flat_Id = @Flat_Id", flatId).ToString();
            total_no_complaint.Text = GetCounts("SELECT COUNT(*) FROM Complaints WHERE Flat_Id = @Flat_Id", flatId).ToString();

          
        }

        // Method to execute count query with parameterized query
        private int GetCount(string query, int userId)
        {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@User_Id", userId);
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            
        }

        private int GetCounts(string query, int flatId)
        {
           
                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    cmd1.Parameters.AddWithValue("@Flat_Id", flatId);
                    object result = cmd1.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Write("<script>alert('Logout successfully!!');window.location.href='Login.aspx';</script>");
        }
    }
}