using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RoomAmenity
    {
        [Key, Column(Order = 0)]
        public int AmenityId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("HotelRoom")]
        public int HotelRoomId { get; set; }

        public HotelRoom HotelRoom { get; set; }

        public Amenity Amenity { get; set; }


    }

}
