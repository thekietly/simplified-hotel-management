using API.Dtos.HotelDto;
using Domain.Entities;
using System.Linq;

namespace API.Mappers
{
    public static class HotelAutoMapper
    {
        public static HotelDto ToHotelDto(this Hotel hotelModel) 
        {
            return new HotelDto
            { 
                Id = hotelModel.Id,
                Name = hotelModel.Name,
                Address = hotelModel.Address,
                TotalReviews = hotelModel.Reviews?.Count() ?? 0,
                AverageReview = hotelModel.Reviews?.Any() == true
                ? hotelModel.Reviews
                    .Select(r => (r.Location + r.ValueForMoney + r.Service + r.Cleanliness + r.Facilities + r.RoomComfortAndQuality) / 6.0)
                    .Average()
                : 0
            };
        }
    }
}
