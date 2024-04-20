using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolApp.Models.DataModels.SecurityModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApiService.Services
{
    public class TokenService : ITokenService
    {
        private const int ExpirationDays = 7;
        private readonly ILogger<TokenService> _logger;

        public TokenService(ILogger<TokenService> logger)
        {
            _logger = logger;
        }

        public string CreateToken(ApplicationUser user)
        {

            var token = CreateJwtToken(user);

            //var payload = new JObject()
            //{
            //    { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()},
            //    { JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()},
            //    { JwtRegisteredClaimNames.Exp, expiration.ToUnixTimeSeconds().ToString()},
            //    { JwtRegisteredClaimNames.Email, user.Email },
            //    { JwtRegisteredClaimNames.GivenName,user.UserName},
            //    { JwtRegisteredClaimNames.Name,user.UserName},
            //    { ClaimTypes.NameIdentifier, user.Id },
            //    { ClaimTypes.Role, user.Role.ToString() }
            //}.ToString();

            //var tokenHandler = new JsonWebTokenHandler();
            //var signingCredentials = CreateSigningCredentials();
            //var jwt = tokenHandler.CreateToken(payload);
            var tokenHandler = new JwtSecurityTokenHandler();
            _logger.LogInformation("JWT Token created");

            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(ApplicationUser user)
        {
            var expiration = DateTime.UtcNow.AddDays(ExpirationDays);
            var claims = CreateClaims(user);
            var credentials = CreateSigningCredentials();

            return new JwtSecurityToken(
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }
        //yyyyMMddHHmmss
        private List<Claim> CreateClaims(ApplicationUser user)
        {
            var jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];

            try
            {
                var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }




    #region Previous_Excluded
    //public interface ITokenService
    //{

    //    Task<string> Get(LoginUser user);
    //}

    //public class TokenService : ITokenService
    //{
    //    private readonly IConfiguration configuration;
    //    private readonly SignInManager<IdentityUser> signInManager;
    //    private readonly UserManager<IdentityUser> userManager;


    //    public TokenService(IConfiguration configuration,     
    //        SignInManager<IdentityUser> signInManager,
    //        UserManager<IdentityUser> userManager)                  
    //    {
    //        this.configuration = configuration;
    //        this.signInManager = signInManager;
    //        this.userManager = userManager;
    //    }
    //    public async Task<string> Get(LoginUser user)
    //    {

    //        var validUser = userManager.Users.SingleOrDefault(u => u.UserName == user.UserName);
    //        if (validUser is null)
    //        {
    //            return "";
    //        }
    //        var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);


    //        if (!result.Succeeded)
    //        {
    //            return "";
    //        }


    //        user.Roles = await userManager.GetRolesAsync(validUser);

    //        try
    //        {

    //            var tokenHandler = new JwtSecurityTokenHandler();

    //            var key = Encoding.UTF8.GetBytes(configuration["Jwt:SignKey"]);


    //            var tokenDescriptor = new SecurityTokenDescriptor()
    //            {
    //                Subject = new ClaimsIdentity(
    //                  new Claim[] {
    //          new Claim(ClaimTypes.Name, user.UserName),
    //            new Claim(ClaimTypes.Role, string.Join(',', user.Roles))

    //                  }),


    //                IssuedAt = DateTime.UtcNow,
    //                Expires = DateTime.UtcNow.AddDays(7),


    //                SigningCredentials = new SigningCredentials(
    //                  new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

    //            };
    //            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);



    //            string jsonToken = tokenHandler.WriteToken(token);

    //            return jsonToken;

    //        }
    //        catch (Exception ex)
    //        {

    //            return "";
    //        }
    //    }
    //}



    //public static class JwtHelper
    //{
    //    public static void AddTokenService(this IServiceCollection service)
    //    {
    //        service.AddScoped<ITokenService, TokenService>();
    //    }
    //} 
    #endregion
}
