using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string? Icon { get; set; }
        public ICollection<RoomAmenity>? RoomAmenities { get; set; }
        public ICollection<HotelAmenity>? HotelAmenities { get; set; }

    }
}
