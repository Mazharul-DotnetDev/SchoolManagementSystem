using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApiService.Services;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels.SecurityModels;

namespace SchoolApiService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SchoolDbContext _context;
        private readonly ITokenService _tokenService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SchoolDbContext context,
            ITokenService tokenService, ILogger<UsersController> logger
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            //student register
            //if (!request.Role.Any(r => r == "Student"))

            //	request.Role.Add("Student");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var role in request.Role)
            {

                if (await this._roleManager.RoleExistsAsync(role))
                {

                }
                else
                {
                    await this._roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new ApplicationUser { UserName = request.Username, Email = request.Email, Role = request.Role };

            var result = await _userManager.CreateAsync(
                 user,
                request.Password!
            );

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, request.Role);
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email, role = request.Role }, request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }






        [HttpPost()]//https://domain.com/api/users/login
        [Route("login")]//https://domain.com/login
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized(request);
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
                Roles = userInDb.Role.ToArray()
            });
        }

        [HttpGet]
        [Route("/GetUsers")]
        public async Task<IActionResult> UserIndex()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> UserIndex(string id)
        {
            return Ok(await _userManager.FindByIdAsync(id));
        }

        [HttpGet]
        [Route("/GetRoles")]
        //[Authorize(Roles = "Admin, ")]
        [Authorize()]
        public async Task<IActionResult> RoleIndex()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        [HttpPost("create-role")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateRole([FromBody] UserRoleDto request)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = request.Name,
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok(request);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("edit-role")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditRole([FromBody] UserRoleDto request)//1234 Admin
        {


            var role = await _roleManager.FindByIdAsync(request.Id);//1234 ADMINS

            if (role == null) return BadRequest();

            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return Ok(request);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("delete-role/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteRole(string id)//1234 Admin
        {


            IdentityRole? role = await _roleManager.FindByIdAsync(id);//1234 ADMIN

            if (role == null) return BadRequest();


            var users = await _userManager.GetUsersInRoleAsync(role.Name);


            if (users.Count > 0)
            {
                return BadRequest("User exists in this role");
            }


            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin, Operator")]
        //[Route("AssignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleDto model)//manager, admin
        {
            try
            {

                var user = await _userManager.FindByIdAsync(model.Id);
                if (user is null) return BadRequest($"User not found by id: {model.Id}");

                var userRoles = await _userManager.GetRolesAsync(user);//existing user roles=> user, manager

                List<string?> dbRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();


                foreach (var role in dbRoles)//admin, user, manager, guest, public  => all roles in db
                {

                    if (model.Role.Contains(role))
                    {
                        if (!userRoles.Contains(role))
                        {
                            await _userManager.AddToRoleAsync(user, role);//
                        }
                        else
                        {
                            //roles already in user
                        }
                    }
                    else
                    {
                        if (userRoles.Contains(role))
                        {
                            await _userManager.RemoveFromRoleAsync(user, role);
                        }
                    }

                }

                user.Role = model.Role;
                await _userManager.UpdateAsync(user);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            return Ok();
        }
    }
}