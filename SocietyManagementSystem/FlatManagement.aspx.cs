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
    public partial class FlatManagement : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                BindGrid();
            }
        }


        private void BindGrid()
        {
            string searchText = "%" + txtSearch.Text.Trim() + "%";
            string query = $"SELECT * FROM Flats WHERE (Flat_No LIKE '{searchText}' OR Floor_No LIKE '{searchText}' OR Block_No LIKE '{searchText}' OR Flat_type LIKE '{searchText}') ORDER BY Created_At DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvFlats.DataSource = dt;
            gvFlats.AllowPaging = ddlPageSize.SelectedValue != "-1";
            gvFlats.PageSize = gvFlats.AllowPaging ? int.Parse(ddlPageSize.SelectedValue) : dt.Rows.Count;
            gvFlats.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvFlats_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFlats.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvFlats_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int flatId = Convert.ToInt32(gvFlats.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditFlat.aspx?FlatId={flatId}");
        }

        protected void gvFlats_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int flatId = Convert.ToInt32(gvFlats.DataKeys[e.RowIndex].Value);
            string query = $"DELETE FROM Flats WHERE Flat_Id = {flatId}";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFlat.aspx");
        }
    }
}







