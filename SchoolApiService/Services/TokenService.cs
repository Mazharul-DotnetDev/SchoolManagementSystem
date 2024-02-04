using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApiService.Services
{
    // ITokenService defines a contract for generating tokens
    public interface ITokenService
    {
        //Method to get a token for a user
        Task<string> Get(LoginUser user);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        //Takes IConfiguration, SignInManager, and UserManager as dependencies for configuration, authentication, and user management.

        public TokenService(IConfiguration configuration
        ,
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager
            )
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        /*
         Get Method:
            Takes LoginUser object containing username and password.
            Core steps:

            Authenticates user:
            Finds user in database.
            Verifies password using signInManager.PasswordSignInAsync.

            Fetches user roles:
            Retrieves user's roles using userManager.GetRolesAsync.

            Generates JWT token:
            Creates a JwtSecurityTokenHandler to handle token creation.
            Fetches signing key from configuration.

            Constructs a SecurityTokenDescriptor with:
            User's identity (username and roles).
            Issued and expiration time.
            Signing credentials using the key.
            Creates a JWT token using the descriptor.
            Returns the token as a string.

            Handles errors:
            Returns an empty string if authentication fails or token creation encounters exceptions.
         */

        // Method to generate a JWT token for a given user
        public async Task<string> Get(LoginUser user)
        {


            // Retrieve the user from the user manager

            var validUser = userManager.Users.SingleOrDefault(u => u.UserName == user.UserName);

            // If the user is not found, return an empty string
            if (validUser is null)
            {
                return "";
            }

            // Attempt to sign in the user with the provided username and password
            var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            // If sign-in fails, return an empty string
            if (!result.Succeeded)
            {
                return "";
            }

            // Retrieve user roles
            user.Roles = await userManager.GetRolesAsync(validUser);

            try
            {

                // Create an instance of JwtSecurityTokenHandler to handle JWT tokens

                var tokenHandler = new JwtSecurityTokenHandler();

                // Get the JWT signing key from the application configuration

                var key = Encoding.UTF8.GetBytes(configuration["Jwt:SignKey"]);

                // Define the properties of the JWT token using a SecurityTokenDescriptor

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    // Set the subject of the token, including user name and roles as claims

                    Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                    new Claim(ClaimTypes.Name, user.UserName)
                    ,
                    new Claim(ClaimTypes.Role, string.Join(',',user.Roles))

                            }),

                    // Set the token's issuance time to the current UTC time

                    IssuedAt = DateTime.UtcNow,

                    // Set the token's expiration time to one week from the issuance time
                    Expires = DateTime.UtcNow.AddDays(7),

                    // Set the signing credentials using the symmetric key and HMACSHA256 signature algorithm

                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                // Create a JWT token based on the provided SecurityTokenDescriptor
                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

                // Write the token to a JSON string

                string jsonToken = tokenHandler.WriteToken(token);

                return jsonToken;

            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }



    
    // Helper class to simplify the registration of the TokenService in the ASP.NET Core dependency injection container

    public static class JwtHelper
    {
        // Extension method to add TokenService to the IServiceCollection
        public static void AddTokenService(this IServiceCollection service)
        {
            // Add a scoped service registration for ITokenService, with the implementation being TokenService
            service.AddScoped<ITokenService, TokenService>();
        }
    }
}
