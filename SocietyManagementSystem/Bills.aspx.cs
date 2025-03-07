using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagementSystem
{
    public partial class Bills : System.Web.UI.Page
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
            using (SqlCommand cmd = new SqlCommand("EXEC displayBills", conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Ensure CommandArgument is not null or empty
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                int bill_id;
                if (int.TryParse(e.CommandArgument.ToString(), out bill_id))
                {
                    // Handle Delete command
                    if (e.CommandName == "Delete")
                    {
                        delete_event(bill_id);
                    }
                    // Handle View command
                    else if (e.CommandName == "View")
                    {
                        Response.Redirect($"ViewBill.aspx?billId={bill_id}");
                    }
                }
              
            }
        
        }


        public void delete_event(int bill_Id)
        {
            string query = $"DELETE FROM Bills WHERE Bill_Id = {bill_Id}";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            DisplayGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DisplayGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (GridView1.Rows.Count > 0 && GridView1.DataKeys.Count > e.RowIndex)
            {
                int bill_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                delete_event(bill_id);
                DisplayGrid();
            }
      
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Debugging: Log the total count of DataKeys
            Response.Write($"Total DataKeys Count: {GridView1.DataKeys.Count}<br/>");

            // Check if the index is within the valid range
            if (e.RowIndex >= 0 && e.RowIndex < GridView1.DataKeys.Count)
            {
                int bill_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // Fetch new values from textboxes
                string billTitle = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBillTitle")).Text;
                decimal amount = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmount")).Text);
                DateTime month = DateTime.Parse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMonth")).Text);

                // Debugging: Log the values
                //Response.Write($"Bill ID: {bill_id}, Title: {billTitle}, Amount: {amount}, Month: {month}<br/>");

                string query = $"EXEC UpdateBill @Bill_Id = {bill_id}, @Bill_Title = '{billTitle}', @Amount = {amount}, @Month = '{month:yyyy-MM-dd}'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    //// Debugging: Log the query
                    //Response.Write($"Executing Query: {query}<br/>");

                    cmd.ExecuteNonQuery();

                    // Debugging: Confirm the query execution
                    Response.Write("Query executed successfully.<br/>");

                    conn.Close();
                }

                GridView1.EditIndex = -1;

                // Refresh the GridView to show updated data
                DisplayGrid();
            }
            else
            {
                // Handle the case where the index is out of range
                // For example, log the error or show an error message
                Response.Write("Index out of range.<br/>");
            }
        }





        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DisplayGrid();
        }
        // Add New Bill
        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            //string billTitle = txtBillTitle.Text;
            //int flatId = Convert.ToInt32(txtFlatId.Text);
            //decimal amount = Convert.ToDecimal(txtAmount.Text);
            //string month = txtMonth.Text;

            //string query = $"INSERT INTO Bills (Flat_Id, Bill_title, Amount, Month, Created_At) VALUES ({flatId}, '{billTitle}', {amount}, '{month}', GETDATE())";

            //using (SqlCommand cmd = new SqlCommand(query, conn))
            //{
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}

            //DisplayGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}