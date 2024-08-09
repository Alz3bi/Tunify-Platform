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
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylist _playlist;

        public PlaylistsController(IPlaylist context)
        {
            _playlist = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            var playlists = await _playlist.GetAllPlaylistsAsync();
            return Ok(playlists);
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await _playlist.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return Ok(playlist);
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.PlaylistId)
            {
                return BadRequest();
            }

            try
            {
                await _playlist.UpdatePlaylistAsync(playlist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
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

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            await _playlist.CreatePlaylistAsync(playlist);
            return Ok(playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _playlist.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            await _playlist.DeletePlaylistAsync(id);

            return NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return _playlist.GetPlaylistByIdAsync(id) != null;
        }
    }
}
