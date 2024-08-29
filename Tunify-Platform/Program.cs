using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            builder.Services.AddTransient<ISong, SongService>();
            builder.Services.AddTransient<IArtist, ArtistService>();
            builder.Services.AddTransient<IPlaylist, PlaylistService>();
            builder.Services.AddTransient<IUser, UserService>();
            builder.Services.AddTransient<IAccount, IdentityAccountService>();
            builder.Services.AddTransient<JwtTokenService>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            Array.Empty<string>()
                        }
                    });
            });

            string connectionStringVar =  builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionStringVar))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionStringVar));

            builder.Services.AddAuthentication(
                options =>
                    {
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
            ).AddJwtBearer(
                options =>
                    {
                        options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>();

            var app = builder.Build();

            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
);


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = string.Empty;
            });

            app.MapControllers();

            //app.MapGet("/", () => "Hello World!");
            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }
    }
}
