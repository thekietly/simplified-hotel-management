using System.ComponentModel.DataAnnotations;

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
        public ICollection<RoomAmenity>? RoomAmenities { get; set; }
        public ICollection<HotelAmenity>? HotelAmenities { get; set; }
    }

}
