using Domain.Entities;
namespace Infrastructure.Data
{
    public static class BookingSeedData
    {
        public static IEnumerable<Booking> GetBookings()
        {
            return new List<Booking>
            {

                new Booking
                {
                    Id = 1,
                    UserId = 1,
                    RoomId = 1,
                    BookingReference = "BR202312001",
                    Status = "Confirmed",
                    TotalPrice = 450.00,
                    NumberOfNights = 3,
                    BookingDate = new DateOnly(2023, 12, 1),
                    CheckInDate = new DateOnly(2023, 12, 10),
                    CheckOutDate = new DateOnly(2023, 12, 13),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Booking
                {
                    Id = 2,
                    UserId = 2,
                    RoomId = 2,
                    BookingReference = "BR202312002",
                    Status = "Pending",
                    TotalPrice = 600.00,
                    NumberOfNights = 4,
                    BookingDate = new DateOnly(2023, 12, 3),
                    CheckInDate = new DateOnly(2023, 12, 20),
                    CheckOutDate = new DateOnly(2023, 12, 24),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Booking
                {
                    Id = 3,
                    UserId = 1,
                    RoomId = 3,
                    BookingReference = "BR202312003",
                    Status = "Cancelled",
                    TotalPrice = 300.00,
                    NumberOfNights = 2,
                    BookingDate = new DateOnly(2023, 12, 5),
                    CheckInDate = new DateOnly(2023, 12, 15),
                    CheckOutDate = new DateOnly(2023, 12, 17),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Booking
                {
                    Id = 4,
                    UserId = 2,
                    RoomId = 4,
                    BookingReference = "BR202312004",
                    Status = "Confirmed",
                    TotalPrice = 750.00,
                    NumberOfNights = 5,
                    BookingDate = new DateOnly(2023, 12, 7),
                    CheckInDate = new DateOnly(2023, 12, 25),
                    CheckOutDate = new DateOnly(2023, 12, 30),
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };
        }
    }
}
