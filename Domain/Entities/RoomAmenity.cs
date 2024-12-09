using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RoomAmenity
    {
        [Required]
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
        [Required]
        [ForeignKey("HotelRoom")]

        public int RoomId { get; set; }

        public virtual HotelRoom? HotelRoom { get; set; }

        public virtual Amenity? Amenity { get; set; }
    }
}
