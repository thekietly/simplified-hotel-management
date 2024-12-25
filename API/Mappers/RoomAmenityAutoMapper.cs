using API.Dtos.RoomAmenityDto;
using Domain.Entities;

namespace API.Mappers
{
    // Similar with HotelAmenityAutoMapper
    public static class RoomAmenityAutoMapper
    {
        public static RoomAmenityDto ToRoomAmenityDto(this IEnumerable<RoomAmenity> roomAmenities) 
        {
            return new RoomAmenityDto
            {
                Id = roomAmenities.First().RoomId,
                AmenityList = roomAmenities.Select(a => a.AmenityId).ToList()
            };
        }
        public static List<RoomAmenity> ToRoomAmenityList(this RoomAmenityDto roomAmenityDto) 
        {
            return roomAmenityDto.AmenityList.Select(amenityId => new RoomAmenity 
            {
                RoomId = roomAmenityDto.Id,
                AmenityId = amenityId
            }).ToList();
        }
    }
}
