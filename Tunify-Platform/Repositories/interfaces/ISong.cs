using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface ISong
    {
        // Create a new song
        Task<Song> CreateSongAsync(Song song);

        // Get a song by ID
        Task<Song> GetSongByIdAsync(int songId);

        // Get all songs
        Task<IEnumerable<Song>> GetAllSongsAsync();

        // Get all songs by a specific artist
        Task<IEnumerable<Song>> GetSongsByArtistIdAsync(int artistId);

        // Get all songs in a specific album
        Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(int albumId);

        // Update an existing song
        Task<Song> UpdateSongAsync(Song song);

        // Delete a song by ID
        Task<bool> DeleteSongAsync(int songId);
    }
}
