using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        public TunifyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistSongs>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SubscriptionId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(ar => ar.Songs)
                .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, SubscriptionType = "Free", Price = 0.00m },
                new Subscription { SubscriptionId = 2, SubscriptionType = "Premium", Price = 9.99m }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "john_doe", Email = "john@example.com", Join_Date = DateTime.Now, SubscriptionId = 1 },
                new User { UserId = 2, Username = "jane_doe", Email = "jane@example.com", Join_Date = DateTime.Now, SubscriptionId = 2 }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist 1", Bio = "This is a bio" },
                new Artist { ArtistId = 2, Name = "Artist 2", Bio = "This is a bio" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, AlbumName = "Album 1", ArtistId = 1, ReleaseDate = DateTime.Now },
                new Album { AlbumId = 2, AlbumName = "Album 2", ArtistId = 2, ReleaseDate = DateTime.Now }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = new TimeSpan(0, 3, 45), Genre = "Pop" },
                new Song { SongId = 2, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration = new TimeSpan(0, 4, 20), Genre = "Rock" }
            );

            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, PlaylistName = "Playlist 1", UserId = 1 },
                new Playlist { PlaylistId = 2, PlaylistName = "Playlist 2", UserId = 2 }
            );

            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { PlaylistId = 1, SongId = 1 },
                new PlaylistSongs { PlaylistId = 1, SongId = 2 },
                new PlaylistSongs { PlaylistId = 2, SongId = 1 }
            );

            var adminRoleId = "1";
            var userRoleId = "2";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "35f1bf8b-47da-44e7-a333-90bd27c2d098", RoleId = adminRoleId }
        );

            base.OnModelCreating(modelBuilder);
        }
    }
}
