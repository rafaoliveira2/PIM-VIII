using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PimApi.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        [Required]
        public string? AppUserId { get; set; }
        
        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}