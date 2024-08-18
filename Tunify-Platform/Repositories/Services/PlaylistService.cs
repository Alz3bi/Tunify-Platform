using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistService : IPlaylist
    {
        private TunifyDbContext _context;

        public PlaylistService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Playlist> AddSongToPlaylistAsync(int playlistId, int songId)
        {
            PlaylistSongs playlistSongs = new PlaylistSongs()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            _context.PlaylistSongs.Add(playlistSongs);
            await _context.SaveChangesAsync();
            var playlist = await GetPlaylistByIdAsync(playlistId);
            return playlist;
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<bool> DeletePlaylistAsync(int playlistId)
        {
            var playlist = await GetPlaylistByIdAsync(playlistId);
            if (playlist == null)
            {
                return false;
            }
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            return await _context.Playlists.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int playlistId)
        {
            return await _context.Playlists.FindAsync(playlistId);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsByUserIdAsync(int userId)
        {
            return await _context.Playlists.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<List<Song>> GetSongsInPlaylistAsync(int playlistId)
        {
            var songs = await _context.PlaylistSongs
                .Where(ps => ps.PlaylistId == playlistId)
                .Select(ps => ps.Song)
                .ToListAsync();
            return songs;
        }

        public async Task<Playlist> UpdatePlaylistAsync(Playlist playlist)
        {
            _context.Playlists.Update(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }
    }
}
