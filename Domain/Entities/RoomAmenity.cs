using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RoomAmenity
    {
        [Key, Column(Order = 0)]
        public int AmenityId { get; set; }

        [Key, Column(Order = 1)]
        public int HotelId { get; set; }
        [Key, Column(Order = 2)]

        public string RoomId { get; set; }

        public virtual HotelRoom? HotelRoom { get; set; }
        public virtual Hotel? Hotel { get; set; }

        public virtual Amenity? Amenity { get; set; }
    }

}
