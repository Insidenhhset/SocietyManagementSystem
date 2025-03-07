using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SocietyManagementSystem
{
    public partial class ViewVisitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["visitorId"] != null)
                {
                    int visitorId;
                    if (int.TryParse(Request.QueryString["visitorId"], out visitorId))
                    {
                        LoadVisitorDetails(visitorId);
                    }
                    else
                    {
                        // Handle invalid Visitor_Id
                        Label1.Text = "Invalid Visitor ID";
                    }
                }
                else
                {
                    Label1.Text = "No Visitor ID provided";
                }
            }
        }

        private void LoadVisitorDetails(int visitorId)
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            string query = @"SELECT v.Visitor_Id, 
                                    f.Flat_No, 
                                    v.Name, 
                                    v.Phone, 
                                    v.Address,
                                    v.Person_to_meet, 
                                    v.Reason,
                                    v.In_datetime, 
                                    COALESCE(CONVERT(VARCHAR, v.Out_datetime, 120), 'NA') AS Out_datetime,
                                    v.Is_in_out 
                            FROM Visitors v
                            INNER JOIN Flats f ON v.Flat_Id = f.Flat_Id
                            WHERE v.Visitor_Id = @Visitor_Id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Visitor_Id", visitorId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Label1.Text = reader["Flat_No"].ToString();
                        Label2.Text = reader["Name"].ToString();
                        Label3.Text = reader["Phone"].ToString();
                        Label4.Text = reader["Address"].ToString();
                        Label5.Text = reader["Person_to_meet"].ToString();
                        Label6.Text = reader["Reason"].ToString();
                        Label7.Text = reader["In_datetime"].ToString();
                        Label8.Text = reader["Is_in_out"].ToString();

                    }
                    else
                    {
                        Label1.Text = "No visitor found";
                    }
                    conn.Close();
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            // Ensure Visitor_Id is present in the query string
            if (Request.QueryString["visitorId"] != null)
            {
                int visitorId;
                if (int.TryParse(Request.QueryString["visitorId"], out visitorId))
                {
                    DateTime outdatetime = Convert.ToDateTime(TextBox1.Text);
                    string outremark = TextBox2.Text;

                    // Validate input
                    if (string.IsNullOrWhiteSpace(outremark))
                    {
                        Response.Write("<script>alert('Out Date & Time cannot be empty!');</script>");
                        return;
                    }

                    // Update visitor record in database
                    UpdateVisitorOutDetails(visitorId, outdatetime, outremark);
                }
                else
                {
                    Response.Write("<script>alert('Invalid Visitor ID!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No Visitor ID provided!');</script>");
             
            }
        }

        private void UpdateVisitorOutDetails(int visitorId, DateTime outdatetime, string outremark)
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string formattedOutDatetime = outdatetime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = @"UPDATE Visitors 
                             SET Out_datetime = @Out_datetime, 
                                 Out_remark = @Out_remark, 
                                 Is_in_out = 'Out'
                             WHERE Visitor_Id = @Visitor_Id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Visitor_Id", visitorId);
                    cmd.Parameters.AddWithValue("@Out_datetime", formattedOutDatetime);
                    cmd.Parameters.AddWithValue("@Out_remark", outremark);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Visitor details updated successfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Update failed. Visitor not found');</script>");
                    }
                }
            }
        }
    }
}
