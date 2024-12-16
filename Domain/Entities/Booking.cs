using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
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

        public virtual User? User { get; set; }
        public virtual HotelRoom? HotelRoom { get; set; }
    }
}
