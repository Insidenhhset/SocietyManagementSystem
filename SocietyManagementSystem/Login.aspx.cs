using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using System.Web.UI;

namespace SocietyManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string em = TextBox1.Text;
            string pass = TextBox2.Text; // Hash password before sending
            string hashPass = new PasswordHelper().HashPassword(pass);
            string q = $"exec check_User '{em}','{hashPass}'";
           
            


            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    UserHelper userHelper = new UserHelper();
                    
                    int userId = int.Parse(dr["User_Id"].ToString());
                    string username = dr["Username"].ToString();
                    string email = dr["Email"].ToString();
                    string role = dr["Urole"].ToString(); // Check correct column name in DB
                    string password = dr["Pass"].ToString();
                    Session["userId"] = userId;
                    Session["flatId"] = userHelper.GetFlatId(userId);
                    Session["username"] = username;
                    Session["email"] = email;
                    Session["role"] = role;

                    bool isAuth = new PasswordHelper().VerifyPassword(password, pass);
                    if ((username == em || email == em) && isAuth && role == "Admin")
                    {
                        Response.Write("<script>alert('Admin Login Success!!');window.location.href='Admin.aspx';</script>");
                    }

                    else if ((username == em || email == em) && isAuth && (role == "User"))
                    {
                

                        Response.Write("<script>alert('User Login Success!!');window.location.href='User.aspx';</script>");
                       
                    }
                   
                }
            }
            else
            {

              

                Response.Write("<script>alert('Invalid Credentials!!')</script>");
            }
        }
    }
}

