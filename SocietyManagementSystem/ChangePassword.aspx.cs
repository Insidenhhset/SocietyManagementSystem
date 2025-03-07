using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentPassword = TextBox1.Text.Trim();
            string newPassword = TextBox2.Text.Trim();
            string confirmPassword = TextBox3.Text.Trim();
            int id = Convert.ToInt32(Session["userId"]?.ToString());

            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) || 
                string.IsNullOrWhiteSpace(TextBox3.Text))
            {

              
                ClientScript.RegisterStartupScript(
              this.GetType(),
              "error",
              "showErrorNotification('Fields cannot be empty'); setTimeout(function() { window.location.href='ChangePassword.aspx'; }, 3000);",
              true
          );
                return;
            }


            if (newPassword != confirmPassword)
            {

                ClientScript.RegisterStartupScript(
              this.GetType(),
              "error",
              "showErrorNotification('Passwords do not match!'); setTimeout(function() { window.location.href='ChangePassword.aspx'; }, 3000);",
              true
          );
                    return;
            }

      
            bool passwordChanged = new UserHelper().ChangeUserPassword(currentPassword, newPassword,id); // Your logic here

            if (passwordChanged)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "showSuccessNotification('Password changed successfully!');setTimeout(function() { window.location.href='Admin.aspx'; }, 3000)", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(
          this.GetType(),
          "error",
          "showErrorNotification('Current Password not match!!'); setTimeout(function() { window.location.href='ChangePassword.aspx'; }, 3000);",
          true
      );
            }
        }

    }
}