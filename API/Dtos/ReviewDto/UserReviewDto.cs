namespace API.Dtos.ReviewDto
{
    public class UserReviewDto
    {
        public int Id { get; set; }
        public required int UserId{ get; set; }
        public required string UserName { get; set; }
        public int NumberOfNights { get; set; }
        public int NumberOfGuests { get; set; }
        public double AverageReview { get; set; }
        public string? Like { get; set; }
        public string? Dislike { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
