using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PimApi.Models;
using PimApi.Repositories;
using System.Security.Claims;

namespace PimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistsController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

private string GetUserId()
        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            if (string.IsNullOrEmpty(id))
            {
                id = User.FindFirstValue("sub");
            }
            
            return id!; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            var playlists = await _playlistRepository.GetPlaylistsDoUsuarioAsync(GetUserId());
            return Ok(playlists);
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            var novaPlaylist = await _playlistRepository.CriarPlaylistAsync(playlist, GetUserId());
            return CreatedAtAction(nameof(GetPlaylists), new { id = novaPlaylist.Id }, novaPlaylist);
        }
        

    }
}