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
    public partial class ViewBill : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                DisplayBillOfUser();
            }

        }

        public void DisplayBillOfUser()
        {
            int bill_id = int.Parse(Request.QueryString["billId"]);
            string q = $"select * from Bills where bill_id={bill_id}";

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr["Flat_id"].ToString();
                    Label2.Text = dr["Bill_title"].ToString();
                    Label3.Text = dr["Month"].ToString();
                    Label4.Text = dr["Amount"].ToString();
                    Label5.Text = dr["Paid_date"].ToString();
                    Label6.Text = dr["Paid_amount"].ToString();
                    Label7.Text = dr["Payment_method"].ToString();
                }
            }
        }

    }
}