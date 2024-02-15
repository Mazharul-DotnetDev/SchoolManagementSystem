using Microsoft.EntityFrameworkCore;

namespace SchoolApiService.Services
{
    //[Keyless]
    public class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
