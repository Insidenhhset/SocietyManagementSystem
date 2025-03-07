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
    public partial class UserCompleintList : System.Web.UI.Page
    {
        SqlConnection conn;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["userId"].ToString());

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
            string q = $"exec displayAllCompleintByUser {id}";
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
                Response.Redirect($"ViewMyCompleint.aspx?id={Complaint_Id}");
            }
        }


    }
}