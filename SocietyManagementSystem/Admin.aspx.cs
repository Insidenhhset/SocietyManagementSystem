using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace SocietyManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);

            if (!IsPostBack)
            {
                int sessionStatus = SessionHelper.CheckSession(HttpContext.Current);

                if (sessionStatus == 1) // Admin
                {
                    LoadDashboardData();
                    LoadAllotmentChart();
                    LoadBillPieChart();
                    return;
                }
                else if (sessionStatus == 0) // User
                {
                    return;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadDashboardData()
        {
            conn.Open();
            try
            {
                total_no_flats.Text = GetCount("SELECT COUNT(*) FROM Flats").ToString();
                total_no_bill.Text = GetCount("SELECT COUNT(*) FROM Bills").ToString();
                total_no_allotment.Text = GetCount("SELECT COUNT(*) FROM Allotments").ToString();
                total_no_in_process_complaint.Text = GetCount("SELECT COUNT(*) FROM Complaints WHERE Status = 'In Progress'").ToString();
                total_no_visitor.Text = GetCount("SELECT COUNT(*) FROM Visitors").ToString();
                total_no_unresolved_comp.Text = GetCount("SELECT COUNT(*) FROM Complaints WHERE Status = 'Unresolved'").ToString();
                total_no_resolve_comp.Text = GetCount("SELECT COUNT(*) FROM Complaints WHERE Status = 'Resolved'").ToString();
                total_no_complaint.Text = GetCount("SELECT COUNT(*) FROM Complaints").ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetCount(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        private void LoadAllotmentChart()
        {
            string query = @"SELECT DATENAME(MONTH, move_in_date) AS MonthName, COUNT(*) AS AllotmentCount 
                             FROM Allotments 
                             WHERE YEAR(move_in_date) = YEAR(GETDATE())
                             GROUP BY DATENAME(MONTH, move_in_date), MONTH(move_in_date) 
                             ORDER BY MONTH(move_in_date)";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int[] allotments = new int[12];

            foreach (DataRow row in dt.Rows)
            {
                string month = row["MonthName"].ToString();
                int count = Convert.ToInt32(row["AllotmentCount"]);

                int index = DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month - 1;
                allotments[index] = count;
            }

            string jsonData = JsonConvert.SerializeObject(allotments);
            allotmentChartData.Value = jsonData;
        }

        private void LoadBillPieChart()
        {
            conn.Open();
            try
            {
                string query = @"SELECT 
                     COUNT(CASE WHEN Payment_method IS NULL THEN 1 END) AS UnpaidBills,
                     COUNT(CASE WHEN Payment_method = 'Cash' THEN 1 END) AS PaidBills 
                 FROM Bills";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int unpaid = Convert.ToInt32(reader["UnpaidBills"]);
                    int paid = Convert.ToInt32(reader["PaidBills"]);

                    int[] pieData = { paid, unpaid };
                    billPieChartData.Value = JsonConvert.SerializeObject(pieData);
                }
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Write("<script>alert('Logout successfully!!');window.location.href='Login.aspx';</script>");
        }
    }
}