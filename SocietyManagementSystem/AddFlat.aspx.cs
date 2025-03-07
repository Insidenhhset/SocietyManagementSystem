
using System.Configuration;
using System.Data.SqlClient;
using System;


namespace SocietyManagementSystem
{
    public partial class AddFlat : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                LoadFlatTypes();
            }
        }

        private void LoadFlatTypes()
        {
            string query = "SELECT DISTINCT Flat_type FROM Flats";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlFlatType.DataSource = dr;
            ddlFlatType.DataTextField = "Flat_type";
            ddlFlatType.DataBind();
            dr.Close();
        }

        protected void btnAddFlat_Click(object sender, EventArgs e)
        {
            // Check if Flat already exists
            string checkQuery = $"SELECT COUNT(*) FROM Flats WHERE Flat_No = '{txtFlatNo.Text.Trim()}' AND Floor_No = '{txtFloorNo.Text.Trim()}'";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                lblError.Visible = true;
                lblError.Text = "Flat Already Exists!";
                return;
            }

            lblError.Visible = false;

            // Insert New Flat if Not Exists
            string query = $"INSERT INTO Flats (Flat_No, Floor_No, Block_No, Flat_type) VALUES ('{txtFlatNo.Text.Trim()}', '{txtFloorNo.Text.Trim()}', '{txtBlockNo.Text.Trim()}', '{ddlFlatType.SelectedValue}')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Response.Redirect("FlatManagement.aspx");
        }
    }
}