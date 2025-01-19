using Domain.Entities;

namespace Infrastructure.Data
{
    public static class BookingSeedData
    {
        public static IEnumerable<Booking> GetBookings(List<HotelRoom> hotelRooms, List<NormalUser> users)
        {
            var bookings = new List<Booking>();
            var random = new Random();
            var statuses = new[] { "Confirmed", "Pending", "Cancelled" };

            foreach (var room in hotelRooms)
            {
                for (int i = 0; i < random.Next(1, 5); i++)
                {
                    var user = users[random.Next(users.Count)];
                    var numberOfNights = random.Next(1, 10);
                    var checkInDate = DateOnly.FromDateTime(DateTime.Now.AddDays(random.Next(1, 30)));
                    var booking = new Booking
                    {
                        Id = bookings.Count + 1,
                        UserId = user.Id,
                        RoomId = room.Id,
                        BookingReference = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                        Status = statuses[random.Next(statuses.Length)],
                        TotalPrice = room.BasePrice * numberOfNights,
                        NumberOfNights = numberOfNights,
                        BookingDate = DateOnly.FromDateTime(DateTime.Now),
                        CheckInDate = checkInDate,
                        CheckOutDate = checkInDate.AddDays(numberOfNights),
                        CreatedDate = DateTime.Now,
                        LastUpdated = DateTime.Now
                    };
                    bookings.Add(booking);
                }
            }
            return bookings;
        }
    }
}
