using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistService : IArtist
    {
        private TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> AddSongToArtistAsync(int artistId, int songId)
        {
            var artist = await GetArtistByIdAsync(artistId);
            if (artist == null)
            {
                return null;
            }
            var song = await _context.Songs.FindAsync(songId);
            if (song == null)
            {
                return null;
            }
            artist.Songs.Add(song);
            _context.SaveChanges();
            return artist;
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            var artist = await GetArtistByIdAsync(artistId);
            if (artist == null)
            {
                return false;
            }
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {
            return await _context.Artists.FindAsync(artistId);
        }

        public async Task<List<Song>> GetSongsByArtistAsync(int artistId)
        {
            List<Song> songs = new List<Song>();
            var artist = await _context.Artists.Include(a => a.Songs).FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (artist == null)
            {
                throw new Exception("Artist not found");
            }

            return songs;
        }

        public async Task<Artist> UpdateArtistAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
