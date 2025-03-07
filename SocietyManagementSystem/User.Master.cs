using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int sessionStatus = SessionHelper.CheckSession(HttpContext.Current);
                int userId = Convert.ToInt32(Session["userId"]);
                
                loggedInuser.InnerText = Session["username"]?.ToString();
                loggedUser.InnerText = Session["username"]?.ToString();
                LoadNotificationCount(userId);
                BindNotifications(userId);
                if (sessionStatus == 1) // Admin
                {
                    return;
                }
                else if (sessionStatus == 0) // User
                {
                    return;
                }

            }

        }


           

        private void LoadNotificationCount(int userId)
        {
            int count = new NotificationHelper().GetUnreadNotificationCount(userId);
            lblNotificationCount.Text = count > 0 ? count.ToString() : "";
        }

        private void BindNotifications(int userId)
        {
            DataTable notifications = new NotificationHelper().GetNotifications(userId);
            rptNotifications.DataSource = notifications;
            rptNotifications.DataBind();
        }

       protected void lnkLogout_Click(object sender, EventArgs e)
{
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "showErrorNotification('Logout successfully!!');setTimeout(function() { window.location.href='Login.aspx'; }, 3000)", true);


            //  Response.Write("<script>alert('Logout successfully!!');window.location.href='Login.aspx';</script>");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "showErrorNotification('Logout successfully!!');setTimeout(function() { window.location.href='Login.aspx'; }, 3000)", true);


            //Response.Write("<script>alert('Logout successfully!!');window.location.href='Login.aspx';</script>");

        }
    }
}
