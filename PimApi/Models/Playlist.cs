using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PimApi.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
        
        public string? Descricao { get; set; }


        public string? AppUserId { get; set; }
        
        [ForeignKey("AppUserId")]
        [JsonIgnore]
        public virtual AppUser? AppUser { get; set; }
    }
}