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
    public partial class ViewMyCompleint : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                DisplayComplaintOfUser();
            }

        }

        public void DisplayComplaintOfUser()
        {
            int Complaint_Id = int.Parse(Request.QueryString["id"]);
            string q = $"exec displayOneUsersComplaint {Complaint_Id}";

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["Username"].ToString();
                    Label2.Text = dr["Flat_No"].ToString();
                    Label3.Text = dr["Description"].ToString();
                    Label4.Text = dr["Status"].ToString();
                    Label5.Text = dr["Master_comment"].ToString();

                    if (dr["Status"].ToString() == "Pending")
                    {
                        master.Visible = false;
                        Label4.CssClass = "badge badge-danger text-light";
                    }
                    else if (dr["Status"].ToString() == "In progress")
                    {
                        Label4.CssClass = "badge badge-warning text-light";
                    }
                    else
                    {
                        Label4.CssClass = "badge badge-success text-light";
                    }
                }
            }
        }

    }
}