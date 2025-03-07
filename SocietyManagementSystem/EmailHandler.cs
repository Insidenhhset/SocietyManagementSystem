using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SocietyManagementSystem
{
    public class EmailHandler
    {
        public EmailHandler() { 
         

        }

        public void sendMailInvoice(string userEmail, string userName, string filepath)
        {
            try
            {
                
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("nitesh@gmail.com", "Society Management System");
                    mail.Subject = "Invoice of Bill";
                    mail.To.Add(userEmail);
                    mail.Body = $"Hello {userName},\n\nDownload your invoice for Electricity Bill.\n\nBest regards,\nSociety Management Team";
                    mail.IsBodyHtml = false;

                    // Check if file exists before attaching
                    if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
                    {
                        mail.Attachments.Add(new Attachment(filepath));
                    }
                    else
                    {
                        Console.WriteLine("File does not exist: " + filepath);
                    }

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("your-app-mail", "your-app-password");  
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                        Console.WriteLine("Email Sent Successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email Sending Failed: " + ex.Message);
            }
        }

    }
}