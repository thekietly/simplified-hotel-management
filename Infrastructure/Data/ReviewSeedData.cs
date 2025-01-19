
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class ReviewSeedData
    {
        public static List<Review> GetReviews(List<Hotel> hotels, List<NormalUser> users)
        {
            var reviews = new List<Review>();
            var random = new Random();
            foreach (var hotel in hotels)
            {
                for (int i = 0; i < random.Next(1, 5); i++)
                {
                    var review = new Review
                    {
                        Id = reviews.Count + 1,
                        HotelId = hotel.Id,
                        UserId = users[random.Next(users.Count)].Id,
                        RoomComfortAndQuality = random.Next(1, 10),
                        Cleanliness = random.Next(1, 10),
                        Service = random.Next(1, 10),
                        Facilities = random.Next(1, 10),
                        ValueForMoney = random.Next(1, 10),
                        Location = random.Next(1, 10),
                        Like = "This is a review for " + hotel.Name,
                        Dislike = "This is a review for " + hotel.Name
                    };
                    reviews.Add(review);
                }
            }
            return reviews;
        }
    }
}
