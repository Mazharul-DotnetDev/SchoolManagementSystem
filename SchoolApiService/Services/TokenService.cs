using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApiService.Services
{
    public interface ITokenService
    {
        
        Task<string> Get(LoginUser user);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        public TokenService(IConfiguration configuration,     
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)                  
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<string> Get(LoginUser user)
        {

            var validUser = userManager.Users.SingleOrDefault(u => u.UserName == user.UserName);
            if (validUser is null)
            {
                return "";
            }
            var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            
            if (!result.Succeeded)
            {
                return "";
            }

            
            user.Roles = await userManager.GetRolesAsync(validUser);

            try
            {

                var tokenHandler = new JwtSecurityTokenHandler();
               
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:SignKey"]);

                
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                      new Claim[] {
              new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(',', user.Roles))

                      }),

                    
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddDays(7),

                    
                    SigningCredentials = new SigningCredentials(
                      new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

                

                string jsonToken = tokenHandler.WriteToken(token);

                return jsonToken;

            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }



    public static class JwtHelper
    {
        public static void AddTokenService(this IServiceCollection service)
        {
            service.AddScoped<ITokenService, TokenService>();
        }
    }
}
