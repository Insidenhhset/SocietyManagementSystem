using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using System.IO;
using System.Web;

namespace SocietyManagementSystem
{
    public partial class UserBill : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);

            if (!IsPostBack)
            {
                DisplayGrid();
            }
        }

        public void DisplayGrid()
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!int.TryParse(Session["userId"]?.ToString(), out int User_id))
            {
                Response.Write("Invalid User ID");
                return;
            }

            string q = "exec displayBillsForUser @User_Id";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@User_Id", User_id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int bill_id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"BillPayment.aspx?bill_id={bill_id}");
            }
        }

        public void getInvoicePdf()
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!int.TryParse(Session["userId"]?.ToString(), out int User_id))
            {
                Response.Write("Invalid User ID");
                return;
            }

            string bill_title = "Invoice", Amount = "0", bill_month = "Unknown", bill_amount = "Pending";
            string payment_Status = "Pending";

            string q = $"exec displayBillsForUser @User_Id='{User_id}'";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                 
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                bill_title = dr["Bill_title"].ToString();
                                Amount = dr["Amount"].ToString();
                                bill_month = dr["Month"].ToString();
                                bill_amount = dr["Paid_amount"].ToString();
                            }
                        }
                    }
                }
            }

            // Ensure the Invoices directory exists
            string invoicesFolder = Server.MapPath("~/Invoices/");
            if (!Directory.Exists(invoicesFolder))
            {
                Directory.CreateDirectory(invoicesFolder);
            }

            // Generate a unique filename for each invoice
            string fileName = $"Invoice_{User_id}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string filePath = Path.Combine(invoicesFolder, fileName);
            Session["filepath"] = filePath;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (PdfWriter writer = new PdfWriter(fs))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                document.Add(new Paragraph(bill_title)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                document.Add(new LineSeparator(new SolidLine()));

                document.Add(new Paragraph($"Bill Amount: {Amount}")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(14));

                document.Add(new Paragraph($"Bill Month: {bill_month}")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(14));

                document.Add(new Paragraph($"Paid Amount: {bill_amount}")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(14));

                payment_Status = string.IsNullOrEmpty(bill_amount) ? "Pending" : "Paid";

                document.Add(new Paragraph($"Paid Status: {payment_Status}")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(14));

                document.Add(new LineSeparator(new SolidLine()));
            }


        }

        protected void downloadBtn_Click(object sender, EventArgs e)
        {
            getInvoicePdf(); // Generate and save the invoice first

            string filePath = Session["filepath"] as string;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string fileName = Path.GetFileName(filePath);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
                HttpContext.Current.Response.WriteFile(filePath);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Write("Error: File not found.");
            }
        }

    }
}
