using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem
{
    public class SessionHelper
    {
        public static int CheckSession(HttpContext context)
        {
            string[] AdminPages = { "Admin.aspx" , "Users.aspx", "AddUser.aspx", "EditUser.aspx", "Profile.aspx", "ChangePassword.aspx" , "Reports.aspx" , "Meeting.aspx" , "AddFlat.aspx" , "EditFlat.aspx" , "FlatManagement.aspx", "Bills.aspx" , "ViewBill.aspx" , "AddBill.aspx", "Complient.aspx", "ComplientView.aspx" , "Visitors.aspx", "AddVisitor.aspx" , "ViewVisitor.aspx" , "AllotmentManagement.aspx", "AddAllotment.aspx" , "EditAllotment.aspx" };
            string[] UserPages = { "User.aspx" , "ChangePassword.aspx" , "MeetingDetails.aspx" , "UserBill.aspx", "UserCompleintList.aspx" , "AddCompleint.aspx", "ViewMyCompleint.aspx" , "UserVisitorList.aspx", "ViewMyVisitor.aspx"  , "BillPayment.aspx"  };


            if (context.Session["username"] != null && context.Session["role"] != null)
            {
                string role = context.Session["role"].ToString();
                string currentPage = context.Request.Url.AbsolutePath.TrimStart('/');


                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {

                    if (AdminPages.Contains(currentPage, StringComparer.OrdinalIgnoreCase))
                    {
                        return 1; // Admin
                    }
                }

                else if (role.Equals("User", StringComparison.OrdinalIgnoreCase))
                {

                    if (UserPages.Contains(currentPage, StringComparer.OrdinalIgnoreCase))
                    {
                        return 0; // User
                    }
                }
              

                context.Response.Write("<script>alert('Access Denied! You are not authorized to view this page.'); window.location.href='Login.aspx';</script>");
                context.Response.End();
                return 2; // Unauthorized access
            }


            context.Response.Write("<script>alert('Your Session Expired! Login Again'); window.location.href='Login.aspx';</script>");
            context.Response.End();
            return 2; // No session found
        }


    }
}