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
    public partial class AddVisitor : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            if (!IsPostBack)
            {
                loadFlatNo();
            }
        }

        

        public void loadFlatNo()
        {
            Dictionary<int, string> flats = new Dictionary<int, string>();

            string q = "SELECT Flat_Id, CONCAT(Block_No, ' - ', Flat_No) AS Block_Flat FROM Flats";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                flats.Add(Convert.ToInt32(dr["Flat_Id"]), dr["Block_Flat"].ToString());
            }

            dr.Close();

            DropDownList1.DataSource = flats;
            DropDownList1.DataTextField = "Value";  // Display Block_No - Flat_No
            DropDownList1.DataValueField = "Key";   // Store Flat_Id as value
            DropDownList1.DataBind();
        }




        protected void btn_Click(object sender, EventArgs e)
        {
            string flatNumber = DropDownList1.SelectedValue;
            
            string visitorName = TextBox1.Text.Trim();
            string phone = TextBox2.Text.Trim();
            string address = TextBox3.Text.Trim();
            string personToMeet = TextBox4.Text.Trim();
            string reasonToMeet = TextBox5.Text.Trim();
            DateTime inDateTime = Convert.ToDateTime(TextBox6.Text);

            if (string.IsNullOrEmpty(visitorName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(flatNumber))
            {
                Response.Write("<script>alert('Please fill in all required fields!');</script>");
                return;
            }

            string query = $"INSERT INTO Visitors (Flat_Id, Name, Phone, Address, Person_to_meet, Reason, In_datetime) " +
                  $"VALUES ('{flatNumber}', '{visitorName}', '{phone}', '{address}', '{personToMeet}', '{reasonToMeet}', '{inDateTime}')";

            SqlCommand cmd = new SqlCommand(query, conn);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Response.Write("<script>alert('Visitor added successfully!');window.location.href='AddVisitor.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Error adding visitor. Please try again.');</script>");
            }

        }
    }
}