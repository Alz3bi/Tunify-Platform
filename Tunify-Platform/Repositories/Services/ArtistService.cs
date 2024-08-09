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

        public async Task<Artist> UpdateArtistAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
