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

            string connectionStringVar =  builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionStringVar));

            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
