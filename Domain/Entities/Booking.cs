namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HotelRoomId { get; set; }
        public string BookingReference { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfNights { get; set; }
        public DateOnly BookingDate { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateTime ActualCheckInDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }
    }
}
