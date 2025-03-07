using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Users : System.Web.UI.Page
    {
        private DataTable usersData; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPageSize.SelectedValue = GridView1.PageSize.ToString();
                LoadUsers(); 
            }
        }

        private void LoadUsers(string searchTerm = "")
        {
            var userList = string.IsNullOrWhiteSpace(searchTerm)
                ? new UserHelper().GetUsers() // Returns List<Users>
                : new UserHelper().GetUsersforSearch(searchTerm); // Returns List<Users>

            GridView1.PageSize = int.TryParse(ddlPageSize.SelectedValue, out int pageSize) ? pageSize : 10;
            GridView1.DataSource = userList; // Directly bind the List
            GridView1.DataBind();

            UpdateEntryLabels(userList.Count); // Pass the list count
        }

        private void UpdateEntryLabels(int totalRecords)
        {
            int startEntry = (GridView1.PageIndex * GridView1.PageSize) + 1;
            int endEntry = Math.Min(startEntry + GridView1.PageSize - 1, totalRecords);
            lblEntries.Text = $"Showing {startEntry} to {endEntry} of";
            lblTotalEntries.Text = $"{totalRecords} entries";
        }


        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadUsers(txtSearch.Text.Trim());
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0; // Reset to first page
            LoadUsers(txtSearch.Text.Trim());
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0; // Reset when searching
            LoadUsers(txtSearch.Text.Trim());
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                bool isDeleted = new UserHelper().DeleteUser(userId);
                string message = isDeleted ? "User deleted successfully." : "Error deleting user.";
                ScriptManager.RegisterStartupScript(this, GetType(), "Notification", $"alert('{message}');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('An error occurred: {ex.Message}');", true);
            }

            LoadUsers(txtSearch.Text.Trim()); // Reload after deletion
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                string userId = e.CommandArgument.ToString();
                Response.Redirect($"EditUser.aspx?Id={userId}");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }
    }
}
