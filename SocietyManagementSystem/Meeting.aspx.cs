using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Meeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = TextBox1.Text.Trim();
            string dateTime = TextBox2.Text.Trim().ToString();
            string location = TextBox3.Text.Trim();
            string agenda = TextBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(dateTime))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "showErrorNotification('Please fill in all required fields.');", true);
                return;
            }

            try
            {
                int userid = Convert.ToInt32(Session["userId"]?.ToString());
                ReportsHelper reportsHelper = new ReportsHelper();
                reportsHelper.AddMeetingDetails(userid,title,dateTime,location,agenda);
                
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "success",
                    "showSuccessNotification('Meeting saved and notifications sent successfully!'); setTimeout(function() { window.location.href='Meeting.aspx'; }, 2000);",
                    true
                );
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", $"showErrorNotification('Error: {ex.Message}');window.location.href='Meeting.aspx';", true);
            }
        }
    }
}