using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Domain.Entities
{
    public class HotelAmenity
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        [JsonIgnore]
        public virtual Hotel? Hotel { get; set; }
        public virtual Amenity? Amenity { get; set; }
    }
}
