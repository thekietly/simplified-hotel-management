using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class HotelAmenity
    {
        [Key, Column(Order = 0)]
        public int AmenityId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public Amenity Amenity { get; set; }
    }
}
