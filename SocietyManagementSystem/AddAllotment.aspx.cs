using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class AddAllotment : System.Web.UI.Page
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
            ddlFlat.Items.Clear();
            if (ddlBlock.SelectedValue == "0") return;

            string query = $"SELECT Flat_Id, Flat_No FROM Flats WHERE Block_No = '{ddlBlock.SelectedValue}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            ddlFlat.DataSource = cmd.ExecuteReader();
            ddlFlat.DataTextField = "Flat_No";
            ddlFlat.DataValueField = "Flat_Id";
            ddlFlat.DataBind();
            ddlFlat.Items.Insert(0, new ListItem("-- Select Flat --", "0"));
        }

        protected void btnAddAllotment_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (ddlUser.SelectedValue == "0" || ddlBlock.SelectedValue == "0" || ddlFlat.SelectedValue == "0" || string.IsNullOrEmpty(txtMoveInDate.Text))
            {
                lblError.Text = "All fields are required!";
                lblError.Visible = true;
                return;
            }

            string checkQuery = $"SELECT COUNT(*) FROM Allotments WHERE Flat_Id = {ddlFlat.SelectedValue} AND move_out_date IS NULL";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            int flatCount = (int)checkCmd.ExecuteScalar();

            if (flatCount > 0)
            {
                lblError.Text = "This flat is already allotted to another user!";
                lblError.Visible = true;
                return;
            }

            string moveOutDate = string.IsNullOrEmpty(txtMoveOutDate.Text) ? "NULL" : $"'{txtMoveOutDate.Text}'";
            string query = $@"
                INSERT INTO Allotments (User_Id, Flat_Id, move_in_date, move_out_date, Created_At) 
                VALUES ({ddlUser.SelectedValue}, {ddlFlat.SelectedValue}, '{txtMoveInDate.Text}', {moveOutDate}, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Response.Redirect("AllotmentManagement.aspx");
        }
    }
}