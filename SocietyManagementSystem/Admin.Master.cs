using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Adminn : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loggedInuser.InnerText = Session["username"]?.ToString();
                loggedUser.InnerText = Session["username"]?.ToString();
                int sessionStatus = SessionHelper.CheckSession(HttpContext.Current);
                setActivePageClass(); // sets the active page by checking current url

                if (sessionStatus == 1) // Admin
                {
                    return;
                }   // authenticate user session
                else if (sessionStatus == 0) // User
                {
                    return;
                }


            }

        }

        public void setActivePageClass()
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();

            if (currentPage == "users.aspx")
            {
                liUser.Attributes["class"] = "active";
                
            }
            else if (currentPage == "FlatManagement.aspx")
            {
                liFlats.Attributes["class"] = "active";
            }
            else if (currentPage == "tables.html")
            {
                liBills.Attributes["class"] = "active";
            }
            else if (currentPage == "price.html")
            {
                liVisitors.Attributes["class"] = "active";
            }
            else if (currentPage == "map.html")
            {
                liReports.Attributes["class"] = "active";
            }
            else if (currentPage == "charts.html")
            {
                liProfile.Attributes["class"] = "active";
            }
            else if (currentPage == "Reports.aspx")
            {
                liVisitors.Attributes["class"] = "active";
            }
            else if (currentPage == "Meeting.aspx")
            {
                liReports.Attributes["class"] = "active";
            }
            else if (currentPage == "Profile.aspx")
            {
                liProfile.Attributes["class"] = "active";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "showSuccessNotification('Logout successfully!!');setTimeout(function() { window.location.href='Login.aspx'; }, 2000)", true);



            //  Response.Write("<script>alert('Logout successfully!!');window.location.href='Login.aspx';</script>");
        }

    }
}