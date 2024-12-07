using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
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
    }
}
