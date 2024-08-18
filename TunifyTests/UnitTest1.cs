using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Services;
using Microsoft.EntityFrameworkCore;

namespace TunifyTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetSongsInPlaylistAsync_ReturnsCorrectSongs()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TunifyDbContext>()
                .UseInMemoryDatabase(databaseName: "TunifyTestDb")
                .Options;

            using (var context = new TunifyDbContext(options))
            {
                var playlistId = 1;
                var songs = new List<Song>
                    {
                        new Song { SongId = 1, Title = "Song 1", Genre = "Rock" },
                        new Song { SongId = 2, Title = "Song 2", Genre = "Pop" }
                    };

                var playlistSongs = new List<PlaylistSongs>
                    {
                        new PlaylistSongs { PlaylistId = playlistId, SongId = 1, Song = songs[0] },
                        new PlaylistSongs { PlaylistId = playlistId, SongId = 2, Song = songs[1] }
                    };

                context.Songs.AddRange(songs);
                context.PlaylistSongs.AddRange(playlistSongs);
                context.SaveChanges();

                var service = new PlaylistService(context);

                // Act
                var result = await service.GetSongsInPlaylistAsync(playlistId);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, s => s.SongId == 1 && s.Title == "Song 1");
                Assert.Contains(result, s => s.SongId == 2 && s.Title == "Song 2");
            }
        }
    }
}