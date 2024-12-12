using Domain.Entities;
namespace Infrastructure.Data
{
    public static class HotelImageGallerySeedData
    {
        public static IEnumerable<HotelImageGallery> GetHotelImageGalleries() 
        {
            return new List<HotelImageGallery> 
            {
                new HotelImageGallery
                {
                    Id = 1,
                    HotelId = 1,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 2,
                    HotelId = 1,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 3,
                    HotelId = 1,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 4,
                    HotelId = 1,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 5,
                    HotelId = 1,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 6,
                    HotelId = 2,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 7,
                    HotelId = 2,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 8,
                    HotelId = 2,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 9,
                    HotelId = 2,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new HotelImageGallery
                {
                    Id = 10,
                    HotelId = 2,
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                }
            };
        
        }
    }
}
