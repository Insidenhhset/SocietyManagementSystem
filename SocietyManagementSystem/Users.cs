using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SocietyManagementSystem
{
    public partial class Users
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string CreatedAt { get; set; }
    }
}