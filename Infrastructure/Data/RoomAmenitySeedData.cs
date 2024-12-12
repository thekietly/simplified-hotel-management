using Domain.Entities;

namespace Infrastructure.Data
{
    public static class RoomAmenitySeedData
    {
        public static IEnumerable<RoomAmenity> GetRoomAmenities() 
        {
            return new List<RoomAmenity>()
            {
                new RoomAmenity
                {
                    RoomId = 1,
                    AmenityId = 1
                }, new RoomAmenity
                {
                    RoomId = 1,
                    AmenityId = 2
                },
                new RoomAmenity
                {
                    RoomId = 1,
                    AmenityId = 3
                },
                new RoomAmenity
                {
                    RoomId = 2,
                    AmenityId = 1
                },
                new RoomAmenity
                {
                    RoomId = 2,
                    AmenityId = 2
                },
                new RoomAmenity
                {
                    RoomId = 2,
                    AmenityId = 3
                }
            };
        }
    }
}
