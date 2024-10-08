﻿using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IArtist
    {
        // Create a new artist
        Task<Artist> CreateArtistAsync(Artist artist);

        // Get an artist by ID
        Task<Artist> GetArtistByIdAsync(int artistId);

        // Get all artists
        Task<IEnumerable<Artist>> GetAllArtistsAsync();

        // Update an existing artist
        Task<Artist> UpdateArtistAsync(Artist artist);

        // Delete an artist by ID
        Task<bool> DeleteArtistAsync(int artistId);

        // Add a song to an artist
        Task<Artist> AddSongToArtistAsync(int artistId, int songId);

        // Get all songs by an artist
        Task<List<Song>> GetSongsByArtistAsync(int artistId);
    }
}
