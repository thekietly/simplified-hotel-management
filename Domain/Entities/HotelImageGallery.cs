using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        public virtual Hotel? Hotel { get; set; }
    }
}
