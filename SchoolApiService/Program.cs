
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApiService.Services;
using SchoolApp.DAL.SchoolContext;
using System.Text;

namespace SchoolApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();



            var connectionString = builder.Configuration.GetConnectionString("LocalDbConnection");
            builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(connectionString));


            //builder.Services.AddDbContext<SchoolDbContext>(opt =>
            //{
            //    opt.UseSqlServer("server = DESKTOP-PQL41F3\\SQLEXPRESS; database = sCHHOLDbApi; trusted_connection =true; trust server certificate =true;");
            //});



            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                //options => options.SignIn.RequireConfirmedAccount = true
                )
                .AddEntityFrameworkStores<SchoolDbContext>();
         





            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTokenService();


            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(opt =>
{


    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SignKey"]);
    //opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true,
    };
    opt.UseSecurityTokenValidators = true;
});




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
