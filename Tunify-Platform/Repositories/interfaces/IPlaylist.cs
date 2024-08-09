using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IPlaylist
    {
        // Create a new playlist
        Task<Playlist> CreatePlaylistAsync(Playlist playlist);

        // Get a playlist by ID
        Task<Playlist> GetPlaylistByIdAsync(int playlistId);

        // Get all playlists
        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();

        // Get all playlists for a specific user
        Task<IEnumerable<Playlist>> GetPlaylistsByUserIdAsync(int userId);

        // Update an existing playlist
        Task<Playlist> UpdatePlaylistAsync(Playlist playlist);

        // Delete a playlist by ID
        Task<bool> DeletePlaylistAsync(int playlistId);
    }
}
