
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class HotelRoomImageGallerySeedData
    {
        public static IEnumerable<HotelRoomImageGallery> GetHotelRoomImageGalleries() 
        {
            return new List<HotelRoomImageGallery>()
            {
                new HotelRoomImageGallery
                {
                    Id = 1,
                    RoomId = 1,
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelRoomImageGallery
                {
                    Id = 2,
                    RoomId = 1,
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelRoomImageGallery
                {
                    Id = 3,
                    RoomId = 2,
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelRoomImageGallery
                {
                    Id = 4,
                    RoomId = 2,
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                }
            };
        }
    }
}
