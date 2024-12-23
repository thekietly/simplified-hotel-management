using API.Dtos.HotelAmenityDto;
using Domain.Entities;

namespace API.Mappers
{
    public static class HotelAmenityAutoMapper
    {
        // Mapping all amenity ids to a list then convert to a dto
        public static HotelAmenityDto ToHotelAmenityDto(this IEnumerable<HotelAmenity> hotelAmenities) 
        {
            if (hotelAmenities == null || !hotelAmenities.Any()) 
            {
                return null;
            }
            return new HotelAmenityDto
            {
                HotelId = hotelAmenities.First().HotelId,
                AmenityIdList = hotelAmenities.Select(ha => ha.AmenityId).ToList()
            };
        }
        public static List<HotelAmenity> ToHotelAmenityList(this HotelAmenityDto hotelAmenity) 
        {
            if (hotelAmenity == null || hotelAmenity.AmenityIdList == null || !hotelAmenity.AmenityIdList.Any())
                return new List<HotelAmenity>();
            // returning a list of hotel amenities that are ready to be processed.
            return hotelAmenity.AmenityIdList.Select(amenityId => new HotelAmenity
            {
                HotelId = hotelAmenity.HotelId,
                AmenityId = amenityId
            }).ToList();
        }
    }
}
