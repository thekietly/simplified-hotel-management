using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual HotelRoom? HotelRoom { get; set; }
        [JsonIgnore]

        public virtual Amenity? Amenity { get; set; }
    }
}
