using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

namespace SocietyManagementSystem
{
    public partial class BillPayment : System.Web.UI.Page
    {
         SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);


            if (!IsPostBack)
            {
                int billid = int.Parse(Request.QueryString["bill_id"]);
                Session["billid"] = billid;
                if (Session["userId"] != null)
                {
                    LoadBillDetails(int.Parse(Session["billid"]?.ToString()));
                }
                else
                {
                    // Redirect to login if session is invalid
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadBillDetails(int billId)
        {
            string query = $"exec Get_BillDetailsByBillId @Bill_Id='{billId}'";
           
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Label1.Text = dr["Flat_Number"].ToString();
                        Label2.Text = dr["Bill_title"].ToString();
                        Label3.Text = Convert.ToDateTime(dr["Month"]).ToString("MMMM yyyy");
                        Label4.Text = dr["Amount"].ToString();
                     
                        Session["billamount"] = dr["Amount"].ToString();
                        TextBox1.Text = dr["Paid_date"] == DBNull.Value ? "" : Convert.ToDateTime(dr["Paid_date"]).ToString("yyyy-MM-dd");
                        TextBox2.Text = dr["Paid_amount"] == DBNull.Value ? "" : dr["Paid_amount"].ToString();
                     
                        if (dr["Payment_method"] != DBNull.Value)
                        {
                            DropDownList1.SelectedValue = dr["Payment_method"].ToString();
                            
                        }
                    }
                }

                string q = $"select * from bills where Bill_Id='{billId}'";
                SqlCommand c = new SqlCommand(q,conn);
                SqlDataReader dr1 = c.ExecuteReader();
                string selectedOption = null;

                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        selectedOption = dr1["Payment_method"].ToString();
                    }
                }

                if (!string.IsNullOrEmpty(selectedOption))
                {
                    TextBox1.ReadOnly = true;
                    TextBox2.ReadOnly = true;
                    DropDownList1.Attributes.Add("disabled", "disabled");
                    Button1.Visible = false;
                    
                }
                else
                {
                    TextBox1.ReadOnly = false;
                    TextBox2.ReadOnly = false;
                    DropDownList1.Attributes.Remove("disabled");
                    Button1.Visible = true;
                }
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null && int.TryParse(Session["userId"].ToString(), out int userId))
            {
                UpdateBillPayment(userId);                

            }
        }

     


        private void UpdateBillPayment(int userId)
        {
      
            if (string.IsNullOrEmpty(Label4.Text) || string.IsNullOrEmpty(TextBox2.Text))
            {
                Response.Write("<script>alert('Error: Bill amount or Paid amount is missing.');</script>");
                return;
            }

          
            if (!decimal.TryParse(Label4.Text, out decimal billAmount))
            {
                Response.Write("<script>alert('Error: Invalid bill amount format in Label.');</script>");
                return;
            }

            if (!decimal.TryParse(TextBox2.Text, out decimal paidAmount))
            {
                Response.Write("<script>alert('Error: Please enter a valid paid amount.');</script>");
                return;
            }

        
            if (paidAmount != billAmount)
            {
                Response.Write("<script>alert('Error: Paid amount must be equal to the bill amount!');</script>");
                return;
            }

            string updateQuery = @"
        UPDATE Bills 
        SET Paid_date = @PaidDate, 
            Paid_amount = @PaidAmount, 
            Payment_method = @PaymentMethod
        WHERE Bill_Id = @BillId";

            int billID = int.Parse(Session["billid"]?.ToString());

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@PaidDate", string.IsNullOrEmpty(TextBox1.Text) ? DBNull.Value : (object)Convert.ToDateTime(TextBox1.Text));
                cmd.Parameters.AddWithValue("@PaidAmount", paidAmount);
                cmd.Parameters.AddWithValue("@PaymentMethod", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@BillId", billID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                EmailHandler emailHandler = new EmailHandler();
                UserBill bill = new UserBill();

                string userName = Session["username"]?.ToString();
                string userMail = Session["email"]?.ToString();


                bill.getInvoicePdf();
                string filepath = Session["filepath"]?.ToString();
                emailHandler.sendMailInvoice(userMail,userName,filepath);
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
                DropDownList1.Attributes.Add("disabled", "disabled");
                Button1.Visible = false;
                Response.Write("<script>alert('Payment updated successfully!');</script>");
                LoadBillDetails(billID);

            }
        }

        
    }
        }
