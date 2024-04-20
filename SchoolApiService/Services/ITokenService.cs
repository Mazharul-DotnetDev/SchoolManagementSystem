using SchoolApp.Models.DataModels.SecurityModels;

namespace SchoolApiService.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
