
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolApiService.Services;
using SchoolApp.DAL.SchoolContext;
using System.Text;
using System.Text.Json.Serialization;

namespace SchoolApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()

            //.AddJsonOptions(options =>
            //{

            //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //})
            ;  // appended with 


            // We are configuring how JSON (JavaScript Object Notation) works in our application.

            // We're telling the system to configure the JSON options (settings).
            // Specifically, we want to handle situations where objects refer to each other in a circular way (like A refers to B, and B refers back to A).

            // The line below ensures that when converting objects to JSON, it won't get stuck in an endless loop when there are circular references.
            // This is common when one object refers to another, and that other object refers back to the first one.


            builder.Services.Configure<JsonOptions>(opt =>
            {
                opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });



            var connectionString = builder.Configuration.GetConnectionString("LocalDbConnection");
            builder.Services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(connectionString));


            //builder.Services.AddDbContext<SchoolDbContext>(opt =>
            //{
            //    opt.UseSqlServer("server = DESKTOP-PQL41F3\\SQLEXPRESS; database = sCHHOLDbApi; trusted_connection =true; trust server certificate =true;");
            //});


            // We're telling the system to add user authentication and authorization capabilities.

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(

                // Here we can specify additional options for user authentication.
                // For example, we could require users to confirm their accounts through email.
                // However, this line is commented out, so it's not active for now.
                // options => options.SignIn.RequireConfirmedAccount = true

                //options => options.SignIn.RequireConfirmedAccount = true
                )
                .AddEntityFrameworkStores<SchoolDbContext>();

            // We're specifying that our user and role information should be stored in the SchoolDbContext.
            // This means the system will use our database (SchoolDbContext) to manage user and role information.


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });


            // We're telling the system to add a custom token service we created.

            builder.Services.AddTokenService();

            // We're configuring the authentication system in our application.
            builder.Services.AddAuthentication(opt =>
            {
                // We're setting up the default authentication scheme to be JWT (JSON Web Token).
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(opt =>
{
    // We're configuring the JWT Bearer authentication, which is a common way to handle authentication using JWTs.

    // We're getting the secret key used for signing and verifying JWTs from our application configuration.

    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SignKey"]);
    //opt.SaveToken = true;

    // We're setting up the validation parameters for the JWT.
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        // We're telling the system to validate the signature of the JWT using the provided secret key.
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
