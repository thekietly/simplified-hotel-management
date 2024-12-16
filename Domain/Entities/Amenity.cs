using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public enum AmenityType
    {
        Hotel, Room, Both
    }
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public AmenityType? AmenityType { get; set; }
        [JsonIgnore]
        public virtual ICollection<RoomAmenity>? RoomAmenities { get; set; }
        [JsonIgnore]
        public virtual ICollection<HotelAmenity>? HotelAmenities { get; set; }
    }

}
