using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApiService.Services;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService tokenService;


        // Constructor to inject necessary dependencies
        public AccountController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;

        }

        // Handle user login via GET request
        [HttpGet]
        public async Task<ActionResult<string>> Login(LoginUser user)
        {
            // Return a response with the JWT token obtained from the token service

            return Ok(await this.tokenService.Get(user));

        }

        // Handle user registration via POST request
        [HttpPost]
        public async Task<ActionResult<string>> RegisterUser(LoginUser user)
        {
            // Create a new IdentityUser based on the provided user information
            var identityUser = new IdentityUser()
            {
                UserName = user.UserName,
                Email = user.UserName,
            };

            // Attempt to create the user using the UserManager
            var result = await this.userManager.CreateAsync(identityUser, user.Password);

            // If user creation is successful, return the JWT token
            if (result.Succeeded)
            {
                return Ok(await this.tokenService.Get(user));
            }
            // If user creation fails, return error details
            else
            {
                return BadRequest(result.Errors);
            }

        }

        // Handle role creation via POST request
        [HttpPost("RoleCreate")]
        public async Task<ActionResult> CreateRole(string role)
        {
            try
            {
                // Create a new IdentityRole based on the provided role name
                var identityRole = new IdentityRole(role);

                // Attempt to create the role using the RoleManager
                var result = await roleManager.CreateAsync(identityRole);

                // If role creation is successful, return the created role
                if (result.Succeeded)
                {
                    return Ok(identityRole);
                }

                // If role creation fails, return error details
                else
                {
                    return BadRequest(result.Errors);
                }

            }
            catch (Exception exc)
            {

                return BadRequest(exc);
            }


        }
    }
}
