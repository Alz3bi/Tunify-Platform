using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongService : ISong
    {
        private TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Song> CreateSongAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<bool> DeleteSongAsync(int songId)
        {
            var song = await GetSongByIdAsync(songId);
            if (song == null)
            {
                return false;
            }
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> GetSongByIdAsync(int songId)
        {
            return await _context.Songs.FindAsync(songId);
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(int albumId)
        {
            return await _context.Songs.Where(s => s.AlbumId == albumId).ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsByArtistIdAsync(int artistId)
        {
            return await _context.Songs.Where(s => s.ArtistId == artistId).ToListAsync();
        }

        public async Task<Song> UpdateSongAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
            return song;
        }
    }
}
