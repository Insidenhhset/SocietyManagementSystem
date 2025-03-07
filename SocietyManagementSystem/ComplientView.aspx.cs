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
    public partial class ComplientView : System.Web.UI.Page
    {
        SqlConnection conn;
        int Complaint_Id;

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
            Complaint_Id = int.Parse(Request.QueryString["id"]);
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

                    // Check if the status is "Resolve"
                    if (dr["Status"].ToString() == "Resolve")
                    {
                        // Hide TextBox1 and DropDownList1, show Label for Master Comment
                        TextBox1.Visible = false;
                        statusDiv.Visible = false;
                        Label5.Visible = true;
                        Button1.Visible = false;
                        Label4.CssClass = "badge badge-success text-light";
                    }
                    else if (dr["Status"].ToString() == "Pending")
                    {
                        // Hide TextBox1 and DropDownList1, show Label for Master Comment
                        TextBox1.Visible = true;
                        statusDiv.Visible = true;
                        Label5.Visible = false;
                        Label4.CssClass = "badge badge-warning text-light";
                    }
                    else
                    {
                        // Show TextBox1 and DropDownList1 for in-progress or other statuses
                        TextBox1.Visible = true;
                        statusDiv.Visible = true;
                        Label5.Visible = true;
                        Label4.CssClass = "badge badge-danger text-light";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Complaint_Id = int.Parse(Request.QueryString["id"]);
            string masterComment, status;
            masterComment = TextBox1.Text;
            status = DropDownList1.Text;

            string q = $"exec updateComplaint {Complaint_Id}, '{masterComment}', '{status}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('complaint updated successfully');</script>");
        }

       
    }
}