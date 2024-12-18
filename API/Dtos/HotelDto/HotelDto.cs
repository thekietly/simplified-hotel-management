namespace API.Dtos.HotelDto
{
    public class HotelDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        // Reviews
        public double AverageReview { get; set; }
        public int TotalReviews { get; set; }
    }
}
