using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = Request.QueryString["Id"];
                Session["userId"] = userId;
                if (!string.IsNullOrEmpty(userId))
                {
                    loaduserdata(Convert.ToInt32(userId));
                }
                else
                {
                    // Redirect back if no ID is found to prevent errors
                    Response.Redirect("Users.aspx");
                }
            }
        }

        public void loaduserdata(int id)
        {
            UserHelper userHelper = new UserHelper();
            var userData = userHelper.fetchUserById(id);
            var data = userData.First(); 
            TextBox1.Text = data.Name;    // 
            TextBox2.Text = data.Email;
            DropDownList1.SelectedValue = data.Role;
            TextBox3.Text = "";
        }

        protected void btnedit_clicked(object sender, EventArgs e)
        {
            // Check if any field is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(DropDownList1.SelectedValue) ||
                string.IsNullOrWhiteSpace(TextBox3.Text))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fields cannot be empty.');", true);
                return; 
            }

            UserHelper userHelper = new UserHelper();
            
            string hashPass = new PasswordHelper().HashPassword(TextBox3.Text);
            userHelper.EditUser(TextBox1.Text,TextBox2.Text,DropDownList1.SelectedValue,hashPass, Convert.ToInt32(Session["userId"]?.ToString()));
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User updated successfully!!.');window.location.href='Users.aspx';", true);
        }

    }
}