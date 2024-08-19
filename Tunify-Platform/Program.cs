using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tunify_Platform.Data;
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
            });

            string connectionStringVar =  builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionStringVar));

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

            app.Run();
        }
    }
}
