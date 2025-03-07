using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace SocietyManagementSystem
{
    public class ReportsHelper
    {
        SqlConnection conn;
       public ReportsHelper()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        public List<Report> GetReports(string reportType,string startdate,string enddate)
        {
            conn.Open();
            List<Report> ReportData = new List<Report>();
            if (reportType.Equals("Bill"))
            {
                string q = $"exec ManageReports @action = 'bill', @startDate = '{startdate}', @endDate = '{enddate}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ReportData.Add(
                            new Report
                            {
                                BillTitle = dr["Bill Title"].ToString(),
                                FlatNo = dr["Flat No"].ToString(),
                                BillAmount = dr["Bill Amount"].ToString(),
                                BillMonth = dr["Bill Month"].ToString(),
                                PaidDate = Convert.ToDateTime(dr["Paid Date"]).ToString("yyyy-MM-dd"),
                                PaymentMethod = string.IsNullOrEmpty(dr["Payment Method"].ToString()) ? "NA" : dr["Payment Method"].ToString(),
                                PaidAmount =string.IsNullOrEmpty(dr["Paid Amount"].ToString()) ? "NA" : dr["Paid Amount"].ToString(),
                                status = string.IsNullOrEmpty(dr["Paid Amount"]?.ToString()) ? "Pending" : "Paid"

                            }
                            );
                    }
                }
            }
            else if (reportType.Equals("Visitor"))
            {
                string q = $"exec ManageReports @action = 'visitor', @startDate = '{startdate}', @endDate = '{enddate}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ReportData.Add(
                            new Report
                            {
                                FlatNo = dr["Flat No"].ToString(),
                                VisitorName = dr["User Name"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Address = dr["Address"].ToString(),
                                PersonToMeet = dr["Person To Meet"].ToString(),
                                Reason = dr["Reason"].ToString(),
                                InDate = dr["In DateTime"].ToString(),
                                OutRemark = dr["Out Remark"].ToString(),
                                OutDate = dr["Out DateTime"].ToString(),
                                VisitorStatus =dr["Status"].ToString()
                            }
                            );
                    }
                }
            }
            else if (reportType.Equals("Complaint"))
            {
                string q = $"exec ManageReports @action = 'complaint', @startDate = '{startdate}', @endDate = '{enddate}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ReportData.Add(
                            new Report
                            {
                                UserName = dr["User Name"].ToString(),
                                FlatNo = dr["Flat No"].ToString(),
                                ComplaintMessage = dr["Complaint Message"].ToString(),
                                ComplaintStatus = dr["Status"].ToString(),
                                ComplaintCreatedAt = dr["Created At"].ToString()
                            }
                            );
                    }
                }
            }

            return ReportData;
        }


        // insert method for meetings
        public void AddMeetingDetails(int userId, string title, string dateTime, string location, string agenda)
        {
            conn.Open();

            string query = $"exec ManageMeetings @action = 'insert',@User_Id = '{userId}',@Title = '{title}', @Date_time = '{dateTime}', @Location = '{location}', @Agenda = '{agenda}'";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}