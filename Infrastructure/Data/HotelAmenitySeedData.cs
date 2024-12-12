
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class HotelAmenitySeedData
    {
        public static IEnumerable<HotelAmenity> GetHotelAmenities() 
        {
            return new List<HotelAmenity>
            {
                new HotelAmenity
                {
                    HotelId = 1,
                    AmenityId = 5
                },
                new HotelAmenity
                {
                    HotelId = 1,
                    AmenityId = 6
                },
                new HotelAmenity
                {
                    HotelId = 1,
                    AmenityId = 7
                }
            };
        }
    }
}
