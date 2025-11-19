using PimApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PimApi.Repositories
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetPlaylistsDoUsuarioAsync(string userId);
        Task<Playlist?> GetPlaylistPorIdAsync(int id, string userId);
        Task<Playlist> CriarPlaylistAsync(Playlist playlist, string userId);
        Task<bool> AtualizarPlaylistAsync(int id, Playlist playlist, string userId);
        Task<bool> DeletarPlaylistAsync(int id, string userId);
    }
}