using Microsoft.EntityFrameworkCore;
using PimApi.Data;
using PimApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimApi.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApiDbContext _context;

        public PlaylistRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Playlist> CriarPlaylistAsync(Playlist playlist, string userId)
        {
            playlist.AppUserId = userId;
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsDoUsuarioAsync(string userId)
        {
            return await _context.Playlists
                .Where(p => p.AppUserId == userId)
                .ToListAsync();
        }

        public async Task<Playlist?> GetPlaylistPorIdAsync(int id, string userId)
        {
            return await _context.Playlists
                .FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId);
        }

        public async Task<bool> AtualizarPlaylistAsync(int id, Playlist playlist, string userId)
        {
            var playlistExistente = await GetPlaylistPorIdAsync(id, userId);
            if (playlistExistente == null) return false;

            playlistExistente.Nome = playlist.Nome;
            playlistExistente.Descricao = playlist.Descricao;

            _context.Entry(playlistExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarPlaylistAsync(int id, string userId)
        {
            var playlist = await GetPlaylistPorIdAsync(id, userId);
            if (playlist == null) return false;

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}