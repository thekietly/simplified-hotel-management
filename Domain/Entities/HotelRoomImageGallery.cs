using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class HotelRoomImageGallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("HotelRoom")]
        public int RoomId { get; set; }
        public string? ImageUrl { get; set; }
        [JsonIgnore]
        public virtual HotelRoom? HotelRoom { get; set; }

    }
}
