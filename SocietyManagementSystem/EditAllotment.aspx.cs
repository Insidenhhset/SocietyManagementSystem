
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class EditAllotment : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                LoadUsers();
                LoadBlocks();
                LoadAllotmentDetails();
            }
        }

        private void LoadUsers()
        {
            string query = "SELECT User_Id, UserName FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            ddlUser.DataSource = cmd.ExecuteReader();
            ddlUser.DataTextField = "UserName";
            ddlUser.DataValueField = "User_Id";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-- Select User --", "0"));
        }

        private void LoadBlocks()
        {
            string query = "SELECT DISTINCT Block_No FROM Flats ORDER BY Block_No";
            SqlCommand cmd = new SqlCommand(query, conn);
            ddlBlock.DataSource = cmd.ExecuteReader();
            ddlBlock.DataTextField = "Block_No";
            ddlBlock.DataValueField = "Block_No";
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("-- Select Block --", "0"));
        }

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFlats();
        }

        private void LoadFlats()
        {
            if (ddlBlock.SelectedValue == "0") return;

            string query = $"SELECT Flat_Id, Flat_No FROM Flats WHERE Block_No = '{ddlBlock.SelectedValue}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            ddlFlat.DataSource = cmd.ExecuteReader();
            ddlFlat.DataTextField = "Flat_No";
            ddlFlat.DataValueField = "Flat_Id";
            ddlFlat.DataBind();
            ddlFlat.Items.Insert(0, new ListItem("-- Select Flat --", "0"));
        }

        private void LoadAllotmentDetails()
        {
            if (int.TryParse(Request.QueryString["AllotmentId"], out int allotmentId))
            {
                string query = $@"
                    SELECT User_Id, Flats.Block_No, Allotments.Flat_Id, move_in_date, move_out_date 
                    FROM Allotments 
                    INNER JOIN Flats ON Allotments.Flat_Id = Flats.Flat_Id 
                    WHERE Allotment_Id = {allotmentId}";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ddlUser.SelectedValue = reader["User_Id"].ToString();
                    ddlBlock.SelectedValue = reader["Block_No"].ToString();
                    LoadFlats();
                    ddlFlat.SelectedValue = reader["Flat_Id"].ToString();
                    txtMoveInDate.Text = Convert.ToDateTime(reader["move_in_date"]).ToString("yyyy-MM-dd");

                    if (reader["move_out_date"] != DBNull.Value)
                    {
                        txtMoveOutDate.Text = Convert.ToDateTime(reader["move_out_date"]).ToString("yyyy-MM-dd");
                    }
                }
                reader.Close();
            }
        }

        protected void btnUpdateAllotment_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["AllotmentId"], out int allotmentId))
            {
                string flatId = ddlFlat.SelectedValue;

                // Check if Flat is Already Allotted to Another User
                string checkQuery = $@"
                    SELECT COUNT(*) FROM Allotments 
                    WHERE Flat_Id = {flatId} AND Allotment_Id != {allotmentId}";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                int flatCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (flatCount > 0)
                {
                    lblError.Text = "This flat is already allotted to another user!";
                    lblError.Visible = true;
                    return;
                }

                string moveOutDate = string.IsNullOrEmpty(txtMoveOutDate.Text) ? "NULL" : $"'{txtMoveOutDate.Text}'";
                string query = $@"
                    UPDATE Allotments 
                    SET User_Id = {ddlUser.SelectedValue}, 
                        Flat_Id = {ddlFlat.SelectedValue}, 
                        move_in_date = '{txtMoveInDate.Text}', 
                        move_out_date = {moveOutDate} 
                    WHERE Allotment_Id = {allotmentId}";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                Response.Redirect("AllotmentManagement.aspx");
            }
        }
    }
}