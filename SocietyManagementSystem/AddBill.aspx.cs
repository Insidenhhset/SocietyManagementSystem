using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class AddBill : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            if (!IsPostBack)  // Load data only on first request
            {
                LoadFlats();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bill_title = TextBox1.Text;
            decimal amount = decimal.Parse(TextBox2.Text);
            string month = TextBox3.Text;
            int flat_no = int.Parse(DropDownList1.Text);


            {
                try
                {
                    conn.Open();

                    // Declare required variables
                    int flat_id = 0, bill_id = 0, user_id = 0;

                    // Step 1: Get Flat ID
                    string flatQuery = "SELECT Flat_Id FROM Flats WHERE Flat_No = @FlatNo";
                    using (SqlCommand cmdFlat = new SqlCommand(flatQuery, conn))
                    {
                        cmdFlat.Parameters.AddWithValue("@FlatNo", flat_no);
                        object result = cmdFlat.ExecuteScalar();
                        if (result != null)
                        {
                            flat_id = Convert.ToInt32(result);
                        }
                        else
                        {
                            Response.Write("<script>alert('Flat not found!');</script>");
                            return;
                        }
                    }

                    // Step 2: Insert Bill
                    string billQuery = "INSERT INTO Bills (flat_id, bill_title, amount, month, created_at) " +
                                       "VALUES (@FlatId, @BillTitle, @Amount, @Month, GETDATE()); " +
                                       "SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmdBill = new SqlCommand(billQuery, conn))
                    {
                        cmdBill.Parameters.AddWithValue("@FlatId", flat_id);
                        cmdBill.Parameters.AddWithValue("@BillTitle", bill_title);
                        cmdBill.Parameters.AddWithValue("@Amount", amount);
                        cmdBill.Parameters.AddWithValue("@Month", month);
                        object billResult = cmdBill.ExecuteScalar();
                        if (billResult != null)
                        {
                            bill_id = Convert.ToInt32(billResult);
                        }
                    }

                    // Step 3: Get the Latest User for the Flat
                    string userQuery = "SELECT TOP 1 User_Id FROM Allotments WHERE Flat_Id = @FlatId ORDER BY move_in_date DESC";
                    using (SqlCommand cmdUser = new SqlCommand(userQuery, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@FlatId", flat_id);
                        object userResult = cmdUser.ExecuteScalar();
                        if (userResult != null)
                        {
                            user_id = Convert.ToInt32(userResult);
                        }
                        else
                        {
                            Response.Write("<script>alert('No user found for this flat!');</script>");
                            return;
                        }
                    }

                    // Step 4: Insert Notification
                    string message = $"New bill '{bill_title}' of ₹{amount} for {month} has been generated.";
                    string link = $"/BillPayment.aspx?bill_id={bill_id}";
                    string notifyQuery = "INSERT INTO Notifications (User_Id, notification_type, event_id, message, link, read_status, Created_At) " +
                                         "VALUES (@UserId, @BillTitle, @BillId, @Message, @Link, 'Unread', GETDATE());";
                    using (SqlCommand cmdNotify = new SqlCommand(notifyQuery, conn))
                    {
                        cmdNotify.Parameters.AddWithValue("@UserId", user_id);
                        cmdNotify.Parameters.AddWithValue("@BillTitle", bill_title);
                        cmdNotify.Parameters.AddWithValue("@BillId", bill_id);
                        cmdNotify.Parameters.AddWithValue("@Message", message);
                        cmdNotify.Parameters.AddWithValue("@Link", link);
                        cmdNotify.ExecuteNonQuery();
                    }

                    // Success Message
                    Response.Write("<script>alert('Bill added successfully!');</script>");

                    // Clear Fields
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    DropDownList1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }




        private void LoadFlats()
        {
            {
                string query = "SELECT Flat_No, Flat_Id FROM Flats"; // Switch order of columns
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DropDownList1.DataSource = dr;
                DropDownList1.DataTextField = "Flat_No";  // Display Name
                DropDownList1.DataValueField = "Flat_No";  // Save Flat_No as Value
                DropDownList1.DataBind();

                dr.Close();
            }

            // Add default option
            DropDownList1.Items.Insert(0, new ListItem("-- Select Falt --", "0"));
        }

    
}
}