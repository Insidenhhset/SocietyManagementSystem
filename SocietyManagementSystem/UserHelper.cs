using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem
{
    public class UserHelper
    {

        SqlConnection conn;
        public UserHelper()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            
        }

        public int GetFlatId(int userId)
        {
            int flatID = 0;


            string query = "SELECT Flat_Id FROM Allotments WHERE User_Id = @UserId";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    flatID = Convert.ToInt32(result);
                }
            }

            return flatID;
        }
        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            conn.Open();

            string q = $"exec ManageUsers @Action='select'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.Add(new Users
                    {
                        ID = Convert.ToInt32(dr["User_Id"]),
                        Name = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        Role = dr["Urole"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["Created_At"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                    }

                        );
                }
            }

            conn.Close();
            return users;
        }

        public List<Users> GetUsersforSearch(string name)
        {
            List<Users> users = new List<Users>();
            conn.Open();

            string q = $"exec ManageUsers @Action = 'search', @Username='{name}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.Add(new Users
                    {
                        ID = Convert.ToInt32(dr["User_Id"]),
                        Name = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        Role = dr["Urole"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["Created_At"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                    }

                        );
                }
            }

            conn.Close();
            return users;
        }
        public bool DeleteUser(int ID)
        {
            conn.Open();
            string q = $"exec ManageUsers @Action = 'delete', @User_Id='{ID}'";
            SqlCommand cmd = new SqlCommand(@q, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
            
        }

        public void AddUser(string name,string email , string role,string password)
        {
            conn.Open();
            string q = $"exec ManageUsers @Action = 'insert' , @Username='{name}', @Email='{email}', @Pass='{password}', @Urole='{role}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
       
         public List<Users> fetchUserById(int id)
        {
            List<Users> users = new List<Users>();
            conn.Open();

            string q = $"exec ManageUsers @Action = 'fetch', @User_Id='{id}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.Add(new Users
                    {
                        ID = Convert.ToInt32(dr["User_Id"]),
                        Name = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        Role = dr["Urole"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["Created_At"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                    }

                        );
                }
            }

            conn.Close();
            return users;
        }

        public void EditUser(string name, string email, string role, string password,int id)
        {
            conn.Open();
            string q = $"exec ManageUsers @Action = 'update' , @Username='{name}', @Email='{email}', @Pass='{password}', @Urole='{role}',@User_Id='{id}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SaveUser(string name,string email,int id)
        {
            
            conn.Open();
            string q = $"exec ManageUsers @Action = 'save' , @User_Id='{id}', @Username='{name}' , @Email='{email}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string getHashPass(int id)
        {
            string q = $"exec ManageUsers @Action = 'checkPass' , @User_Id='{id}'";
            SqlCommand cmd = new SqlCommand(q , conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string Pass = null;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pass = dr["Pass"].ToString();
                }
            }
            return Pass;
        }
        public bool ChangeUserPassword(string currentPass , string newPass,int id)
        {
            conn.Open();
            string hashPass = getHashPass(id);
            PasswordHelper passwordHelper = new PasswordHelper();
            bool isVerified = passwordHelper.VerifyPassword(hashPass, currentPass); // if user entere pass correct then only proceed further

           
            if (!isVerified)  // if isverified is false then return false
            {
                return false;
            }
            string hashNewPass = passwordHelper.HashPassword(newPass);
            string q = $"exec ManageUsers @Action = 'changePass' , @User_Id='{id}' ,@Pass='{hashNewPass}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;

        }
    }
}