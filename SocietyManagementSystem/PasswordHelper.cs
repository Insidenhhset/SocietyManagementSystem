using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SocietyManagementSystem
{
    public  class PasswordHelper
    {
        public  string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2")); // Convert to hex string
                return builder.ToString();
            }
        }

        // Method to verify if the provided password matches the hashed password
        public  bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            string hashedProvidedPassword = HashPassword(providedPassword); // Hash the provided password
            return hashedPassword.Equals(hashedProvidedPassword);           // Compare the hashes
        }
    }
}