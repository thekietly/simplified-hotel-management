using API.Dtos.ReviewDto;
using Domain.Entities;
using System.Collections.Generic;

namespace API.Mappers
{
    public static class ReviewAutoMapper
    {
        public static UserReviewDto ToUserReviewDto(this Review review)
        {
            var averageReview = (review.Cleanliness
                + review.Facilities
                + review.RoomComfortAndQuality
                + review.ValueForMoney
                + review.Location
                + review.Service) / 6.0;
            return new UserReviewDto
            {
                Id = review.Id,
                UserId = review.UserId,
                UserName = review.User.Email,
                AverageReview = averageReview,
                Like = review.Like,
                Dislike = review.Dislike,
                CreatedDate = review.CreatedDate
            };
        }
        public static OverallReviewDto ToOverallReviewDto(this IEnumerable<Review> reviews) 
        {
            // If no reviews for this hotel
            if (reviews == null || !reviews.Any())
            {
                return new OverallReviewDto
                {
                    AverageLocationReview = 0,
                    AverageValueForMoneyReview = 0,
                    AverageCleanlinessReview = 0,
                    AverageServiceReview = 0,
                    AverageFacilitiesnReview = 0,
                    AverageRoomComfortAndQualityReview = 0,
                    OverallAverageAllCategories = 0,
                    TotalReviews = 0
                };
            }
            // Calculate the average reviews of each category of this hotel
            int totalReviews = reviews.Count();
            var overallReviewDto = new OverallReviewDto
            {
                AverageLocationReview = reviews.Average(r => r.Location),
                AverageValueForMoneyReview = reviews.Average(r => r.ValueForMoney),
                AverageCleanlinessReview = reviews.Average(r => r.Cleanliness),
                AverageServiceReview = reviews.Average(r => r.Service),
                AverageFacilitiesnReview = reviews.Average(r => r.Facilities),
                AverageRoomComfortAndQualityReview = reviews.Average(r => r.RoomComfortAndQuality),
                TotalReviews = totalReviews
            };
            // Calculate the overall average reviews
            overallReviewDto.OverallAverageAllCategories =
                (overallReviewDto.AverageLocationReview +
                overallReviewDto.AverageValueForMoneyReview +
                overallReviewDto.AverageCleanlinessReview +
                overallReviewDto.AverageServiceReview +
                overallReviewDto.AverageFacilitiesnReview +
                overallReviewDto.AverageRoomComfortAndQualityReview) / 6.0;

            return overallReviewDto;
        }
    }
}
