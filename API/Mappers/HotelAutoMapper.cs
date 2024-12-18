using API.Dtos.HotelDto;
using Domain.Entities;
using System.Linq;

namespace API.Mappers
{
    public static class HotelAutoMapper
    {
        public static HotelDto ToHotelDto(this Hotel hotelModel) 
        {
            var reviews = hotelModel.Reviews ?? new List<Review>();
            // Calculate average of all 6 categories if this hotel has any reviews.
            var averageLocation = reviews.Any() ? reviews.Average(r => r.Location) : 0;
            var averageValueForMoney = reviews.Any() ? reviews.Average(r => r.ValueForMoney) : 0;
            var averageService = reviews.Any() ? reviews.Average(r => r.Service) : 0;
            var averageCleanliness = reviews.Any() ? reviews.Average(r => r.Cleanliness) : 0;
            var averageFacilities = reviews.Any() ? reviews.Average(r => r.Facilities) : 0;
            var averageRoomComfort = reviews.Any() ? reviews.Average(r => r.RoomComfortAndQuality) : 0;

            // calculate averageg of all the categories above
            var averageReview = (averageLocation + averageValueForMoney + averageService + averageCleanliness + averageFacilities + averageRoomComfort) / 6.0;
            
            return new HotelDto
            { 
                Id = hotelModel.Id,
                Name = hotelModel.Name,
                Address = hotelModel.Address,
                TotalReviews = hotelModel.Reviews?.Count() ?? 0,
                AverageReview = averageReview
            };
        }
    }
}
