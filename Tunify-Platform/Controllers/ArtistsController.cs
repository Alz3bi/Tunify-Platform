using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artist;

        public ArtistsController(IArtist artist)
        {
            _artist = artist;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists = await _artist.GetAllArtistsAsync();
            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artist.GetArtistByIdAsync(id);
            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            try
            {
                await _artist.UpdateArtistAsync(artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            await _artist.CreateArtistAsync(artist);
            return Ok(artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artist.GetArtistByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artist.DeleteArtistAsync(id);

            return NoContent();
        }

        // POST: api/Artists/5/songs/3
        [HttpPost("{artistId}/songs/{songId}")]
        public async Task<ActionResult<Artist>> AddSongToArtist(int artistId, int songId)
        {
            var artist = await _artist.AddSongToArtistAsync(artistId, songId);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        // GET: api/Artists/5/songs
        [HttpGet("{artistId}/songs")]
        public async Task<ActionResult<List<Song>>> GetSongsByArtist(int artistId)
        {
            var songs = await _artist.GetSongsByArtistAsync(artistId);
            return Ok(songs);
        }

        private bool ArtistExists(int id)
        {
            return _artist.GetArtistByIdAsync(id) != null;
        }
    }
}
