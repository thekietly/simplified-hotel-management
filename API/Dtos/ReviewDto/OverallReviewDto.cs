namespace API.Dtos.ReviewDto
{
    public class OverallReviewDto
    {
        public double AverageLocationReview { get; set; }
        public double AverageValueForMoneyReview { get; set; }
        public double AverageCleanlinessReview { get; set; }
        public double AverageServiceReview { get; set; }
        public double AverageFacilitiesnReview { get; set; }
        public double AverageRoomComfortAndQualityReview { get; set; }
        public double OverallAverageAllCategories {  get; set; }
        public int TotalReviews { get; set; }

    }
}
