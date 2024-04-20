using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels.SecurityModels
{
    public class AuthResponse
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string Roles { get; set; } = "";
    }
}
