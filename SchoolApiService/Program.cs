using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolApiService.Services;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels.SecurityModels;
using System.Text;
using System.Text.Json.Serialization;

namespace SchoolApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors();


            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy
            //                          .AllowAnyOrigin()
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod();
            //                      });
            //});


            //builder.Services.AddControllers();

            // Or the following
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //options.JsonSerializerOptions.PropertyNamingPolicy = null;

                //support string to enum converter
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });



            //builder.Services.Configure<JsonOptions>(opt =>
            //{
            //	opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});

            var connectionString = builder.Configuration.GetConnectionString("LocalDbConnection");
            builder.Services.AddDbContext<SchoolDbContext>(options =>
              options.UseSqlServer(connectionString));

            //builder.Services.AddDbContext<SchoolDbContext>(opt =>
            //{
            //    opt.UseSqlServer("server = DESKTOP-PQL41F3\\SQLEXPRESS; database = sCHHOLDbApi; trusted_connection =true; trust server certificate =true;");
            //});



            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
.AddRoles<IdentityRole>().AddEntityFrameworkStores<SchoolDbContext>();




            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Demo API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
              new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                  Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
              },
              new string[] {}
            }
          });
            });



            //builder.Services.AddTokenService();

            builder.Services.AddScoped<ITokenService, TokenService>();


            #region Excluded
            //builder.Services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(opt =>
            //{


            //    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SignKey"]);
            //    //opt.SaveToken = true;
            //    opt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true,
            //    };
            //    opt.UseSecurityTokenValidators = true;
            //}); 
            #endregion

            var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
            var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
            var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.UseSecurityTokenValidators = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
            SaveSigninToken = true
        };
    });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            //app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
            });

            //app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
