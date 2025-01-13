using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        [Required]
        [ForeignKey("HotelRoom")]
        public int RoomId { get; set; }
        public required string BookingReference { get; set; }
        public required string Status { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfNights { get; set; }
        public DateOnly BookingDate { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

        [JsonIgnore]
        public virtual IdentityUser? User { get; set; }
        [JsonIgnore]
        public virtual HotelRoom? HotelRoom { get; set; }
    }
}
