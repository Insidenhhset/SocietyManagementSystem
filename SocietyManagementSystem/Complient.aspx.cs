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
    public partial class Complient : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                DisplayGrid();
            }

        }

        public void DisplayGrid()
        {

            string q = "exec displayComplaintToAdmin";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Complaint_Id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "View")
            {
                Response.Redirect($"ComplientView.aspx?id={Complaint_Id}");
            }
            else if (e.CommandName == "Delete")
            {
                Delete_Complient(Complaint_Id);
            }
        }

        public void Delete_Complient(int id)
        {
            string query = $"delete from Complaints where Complaint_Id = '{id}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            DisplayGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

    }
}