using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnExport.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
            }
        }

        public void loadBillReport(List<Report> ReportData)
        {
            GridView1.DataSource = ReportData;
            GridView1.DataBind();

        }

        public void loadComplaintData(List<Report> ReportData)
        {
            GridView2.DataSource = ReportData;
            GridView2.DataBind();

        }

        public void loadVisitorReport(List<Report> ReportData)
        {
            GridView3.DataSource = ReportData;
            GridView3.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string reportType = DropDownList1.SelectedValue;
            string startDate = TextBox1.Text;
            string endDate = TextBox2.Text;

            ReportsHelper reportsHelper = new ReportsHelper();
            List<Report> reportData =  reportsHelper.GetReports(reportType, startDate, endDate);

            if (reportType.Equals("Bill"))
            {
                reporttitle.InnerText = $"{reportType} Data for {startDate} to {endDate} Date";
                loadBillReport(reportData);
                ViewState["ReportData"] = reportData;
                btnExport.Visible = true;
                VisitorData.Visible = false;
                complaintData.Visible = false;
                billData.Visible = true;

            }
            else if (reportType.Equals("Complaint"))
            {
                complainttitle.InnerText = $"{reportType} Data for {startDate} to {endDate} Date";
                loadComplaintData(reportData);
                ViewState["ReportData"] = reportData;
                Button2.Visible  = true;
                billData.Visible = false;
                VisitorData.Visible = false;
                complaintData.Visible = true;
            }
            else if (reportType.Equals("Visitor"))
            {
                visitortitle.InnerText = $"{reportType} Data for {startDate} to {endDate} Date";
                loadVisitorReport(reportData);
                ViewState["ReportData"] = reportData;
                Button3.Visible = true;
                billData.Visible = false;
                complaintData.Visible = false;
                VisitorData.Visible = true;
            }


        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (ViewState["ReportData"] is List<Report> reportData && reportData.Count > 0)
            {
                StringBuilder csv = new StringBuilder();

                // Header
                csv.AppendLine("Bill Title,Flat No,Bill Amount,Bill Month,Paid Date,Payment Method,Paid Amount,Status");

                // Rows
                foreach (var report in reportData)
                {
                    csv.AppendLine($"\"{report.BillTitle}\",{report.FlatNo},{report.BillAmount},\"{report.BillMonth}\",{report.PaidDate:yyyy-MM-dd},\"{report.PaymentMethod}\",{report.PaidAmount},\"{report.status}\"");
                }

                // Export to CSV
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", $"attachment;filename={DropDownList1.SelectedValue}_Report_{DateTime.Now:yyyyMMdd}.csv");
                Response.Write(csv.ToString());
                Response.End();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ViewState["ReportData"] is List<Report> reportData && reportData.Count > 0)
            {
                StringBuilder csv = new StringBuilder();

                // Header
                csv.AppendLine("Flat No,Visitor Name,Phone,Address,Person To Meet,Reason,In Date,Out Remark,Out Date,Status");

                // Rows
                foreach (var report in reportData)
                {
                    csv.AppendLine($"\"{report.FlatNo}\",\"{report.VisitorName}\",\"{report.Phone}\",\"{report.Address}\",\"{report.PersonToMeet}\",\"{report.Reason}\",\"{report.InDate}\",\"{report.OutRemark}\",\"{report.OutDate}\",\"{report.VisitorStatus}\"");
                }

                // Export to CSV
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", $"attachment;filename=Visitor_Report_{DateTime.Now:yyyyMMdd}.csv");
                Response.Write(csv.ToString());
                Response.End();
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ViewState["ReportData"] is List<Report> reportData && reportData.Count > 0)
            {
                StringBuilder csv = new StringBuilder();

                // Header
                csv.AppendLine("User Name,Flat No,Complaint Message,Status,Created At");

                // Rows
                foreach (var report in reportData)
                {
                    csv.AppendLine($"\"{report.UserName}\",\"{report.FlatNo}\",\"{report.ComplaintMessage}\",\"{report.ComplaintStatus}\",\"{report.ComplaintCreatedAt}\"");
                }

                // Export to CSV
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", $"attachment;filename=Complaint_Report_{DateTime.Now:yyyyMMdd}.csv");
                Response.Write(csv.ToString());
                Response.End();
            }

        }
    }
}