using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSavedData();
            }

        }

        public void loadSavedData()
        {
            TextBox1.Text = Session["username"]?.ToString();
            TextBox2.Text = Session["email"]?.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            int id = Convert.ToInt32(Session["userId"]?.ToString());
            UserHelper userHelper = new UserHelper();

            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fields cannot be empty.');", true);
                return;
            }

            userHelper.SaveUser(name, email, id);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User Saved successfully!!.');window.location.href='Admin.aspx';", true);

        }
    }
}