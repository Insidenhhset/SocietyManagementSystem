using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class MeetingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string meetingIdQuery = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(meetingIdQuery) && int.TryParse(meetingIdQuery, out int meetingId))
                {
                    LoadMeetingDetails(meetingId);
                 
                }
                else
                {
                  
                    Response.Write("<script>window.location.href='User.aspx';</script>");
                }
            }

            
        }

        public void LoadMeetingDetails(int meetingId)
        {
            Tuple < string, string, string, string> meetingDetails = new NotificationHelper().GetMeetingDetails(meetingId);

            lblTitle.Text = meetingDetails.Item1;
            lblDateTime.Text = meetingDetails.Item2;
            lblLocation.Text = meetingDetails.Item3;
            lblAgenda.Text = meetingDetails.Item4;

        }
    }
}