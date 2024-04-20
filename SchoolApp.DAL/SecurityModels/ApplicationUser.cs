using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels.SecurityModels
{
    public class ApplicationUser : IdentityUser
    {
        public IList<string> Role { get; set; } = [];
    }

    public class UserRoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
