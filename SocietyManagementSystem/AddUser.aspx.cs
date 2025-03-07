using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text.Trim();
            string email = TextBox2.Text.Trim();
            string password = TextBox3.Text.Trim();
            string role = DropDownList1.SelectedValue;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                string HashPass = new PasswordHelper().HashPassword(password);
                new UserHelper().AddUser(name, email, role, HashPass);


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User added successfully!');window.location.href='Users.aspx';", true);


                TextBox1.Text = TextBox2.Text = TextBox3.Text = string.Empty;
            }
        }
    }
}