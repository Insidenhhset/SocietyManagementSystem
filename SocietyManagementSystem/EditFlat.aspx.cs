using System.Configuration;
using System.Data.SqlClient;
using System;

namespace SocietyManagementSystem
{
    public partial class EditFlat : System.Web.UI.Page
    {
        SqlConnection conn;
        int flatId;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                if (Request.QueryString["FlatId"] != null)
                {
                    flatId = Convert.ToInt32(Request.QueryString["FlatId"]);
                    LoadFlatDetails(flatId);
                    LoadFlatTypes();
                }
                else
                {
                    Response.Redirect("FlatManagement.aspx");
                }
            }
        }

        private void LoadFlatDetails(int id)
        {
            string query = $"SELECT * FROM Flats WHERE Flat_Id = {id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFlatNo.Text = reader["Flat_No"].ToString();
                txtFloorNo.Text = reader["Floor_No"].ToString();
                txtBlockNo.Text = reader["Block_No"].ToString();
                ddlFlatType.SelectedValue = reader["Flat_type"].ToString();
            }
            reader.Close();
        }

        private void LoadFlatTypes()
        {
            string query = "SELECT DISTINCT Flat_type FROM Flats";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ddlFlatType.Items.Clear();
            while (reader.Read())
            {
                ddlFlatType.Items.Add(reader["Flat_type"].ToString());
            }
            reader.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            flatId = Convert.ToInt32(Request.QueryString["FlatId"]);
            string checkQuery = $"SELECT COUNT(*) FROM Flats WHERE Flat_No='{txtFlatNo.Text.Trim()}' AND Floor_No='{txtFloorNo.Text.Trim()}' AND Flat_Id != {flatId}";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            int existingCount = (int)checkCmd.ExecuteScalar();

            if (existingCount > 0)
            {
                lblError.Text = "<div class='alert alert-danger'>Flat Already Exists!</div>";
                return;
            }

            string query = $"UPDATE Flats SET Flat_No='{txtFlatNo.Text.Trim()}', Floor_No='{txtFloorNo.Text.Trim()}', Block_No='{txtBlockNo.Text.Trim()}', Flat_type='{ddlFlatType.SelectedValue}' WHERE Flat_Id={flatId}";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Response.Redirect("FlatManagement.aspx");
        }
    }
}