using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocietyManagementSystem;

namespace SocietyManagementSystem
{
    public partial class AllotmentManagement : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                ddlPageSize.SelectedValue = "-1"; // Default to "All"
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string searchText = txtSearch.Text.Trim();
            string query = $@"
                SELECT 
                    A.Allotment_Id, 
                    U.Username AS AllotedTo, 
                    F.Flat_No AS FlatNumber, 
                    F.Block_No AS BlockNumber, 
                    F.Flat_type AS Type, 
                    A.move_in_date, 
                    A.move_out_date, 
                    A.Created_At 
                FROM Allotments A
                JOIN Users U ON A.User_Id = U.User_Id
                JOIN Flats F ON A.Flat_Id = F.Flat_Id
                WHERE 
                    U.Username LIKE '%{searchText}%' 
                    OR F.Flat_No LIKE '%{searchText}%'
                    OR F.Block_No LIKE '%{searchText}%'
                    OR F.Flat_type LIKE '%{searchText}%'
                ORDER BY A.Created_At DESC";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvAllotments.DataSource = dt;

            if (ddlPageSize.SelectedValue == "-1") // Show all
            {
                gvAllotments.AllowPaging = false;
            }
            else
            {
                gvAllotments.AllowPaging = true;
                gvAllotments.PageSize = int.Parse(ddlPageSize.SelectedValue);
            }

            gvAllotments.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvAllotments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllotments.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvAllotments_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int allotmentId = Convert.ToInt32(gvAllotments.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditAllotment.aspx?AllotmentId={allotmentId}");
        }

        protected void gvAllotments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int allotmentId = Convert.ToInt32(gvAllotments.DataKeys[e.RowIndex].Value);
            string query = $"DELETE FROM Allotments WHERE Allotment_Id = {allotmentId}";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAllotment.aspx");
        }
    }
}








     
