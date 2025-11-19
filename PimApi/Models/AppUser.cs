using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PimApi.Models
{
    public class AppUser : IdentityUser
    {

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}