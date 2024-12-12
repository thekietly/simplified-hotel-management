
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class ReviewSeedData
    {
        public static IEnumerable<Review> GetReviews() 
        {
            return new List<Review> 
            {
                new Review
                {
                    Id = 1,
                    HotelId = 1,
                    Location = 8,
                    ValueForMoney = 7,
                    Service = 9,
                    Cleanliness = 8,
                    Facilities = 7,
                    RoomComfortAndQuality = 8,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Review
                {
                    Id = 2,
                    HotelId = 1,
                    Location = 9,
                    ValueForMoney = 8,
                    Service = 9,
                    Cleanliness = 9,
                    Facilities = 8,
                    RoomComfortAndQuality = 9,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Review
                {
                    Id = 3,
                    HotelId = 1,
                    Location = 7,
                    ValueForMoney = 6,
                    Service = 7,
                    Cleanliness = 7,
                    Facilities = 6,
                    RoomComfortAndQuality = 7,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new Review
                {
                    Id = 4,
                    HotelId = 1,
                    Location = 10,
                    ValueForMoney = 9,
                    Service = 10,
                    Cleanliness = 9,
                    Facilities = 10,
                    RoomComfortAndQuality = 10,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };
        }
    }
}
