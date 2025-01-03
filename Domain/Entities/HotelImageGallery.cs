using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class HotelImageGallery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public string? ImageUrl { get; set; }
        [JsonIgnore]

        public virtual Hotel? Hotel { get; set; }
    }
}
