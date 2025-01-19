using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Data
{
    public static class HotelSeedData
    {
        public static IEnumerable<Hotel> GetHotels(List<IdentityUser> hotelAdmins)
        {
            var hotelAdminArray = hotelAdmins.ToArray();
            return new List<Hotel>
            {
                CreateHotel(
                    id: 1,
                    name: "Best Arena Hotel",
                    address: "1234, 5th Avenue, Adelaide",
                    description: "Nestled in the heart of the city, the Best Arena Hotel is a luxurious haven that combines elegance, comfort, and exceptional service.",
                    imageUrl: "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    size: 200,
                    ownerId: hotelAdminArray[0].Id
                ),
                CreateHotel(
                    id: 2,
                    name: "Adelaide Oasis Hotel",
                    address: "5678, 6th Avenue, Adelaide",
                    description: "Situated in the vibrant heart of Adelaide, the Adelaide Oasis Hotel offers a peaceful retreat amidst the city’s bustling atmosphere.",
                    imageUrl: "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    size: 150,
                    ownerId: hotelAdminArray[1].Id
                ),
                CreateHotel(
                    id: 3,
                    name: "City Lights Hotel",
                    address: "9101, 7th Avenue, Adelaide",
                    description: "City Lights Hotel offers a modern and stylish stay with stunning views of the city skyline.",
                    imageUrl: "https://images.pexels.com/photos/261102/pexels-photo-261102.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    size: 180,
                    ownerId: hotelAdminArray[2].Id
                ),
                CreateHotel(
                    id: 4,
                    name: "Seaside Resort",
                    address: "1213, Beach Road, Adelaide",
                    description: "Seaside Resort is a perfect getaway with beautiful ocean views and luxurious amenities.",
                    imageUrl: "https://images.pexels.com/photos/261187/pexels-photo-261187.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    size: 250,
                    ownerId: hotelAdminArray[3].Id
                ),
                CreateHotel(
                    id: 5,
                    name: "Mountain Retreat",
                    address: "1415, Hilltop Lane, Adelaide",
                    description: "Mountain Retreat offers a serene escape with breathtaking mountain views and top-notch facilities.",
                    imageUrl: "https://images.pexels.com/photos/261169/pexels-photo-261169.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    size: 220,
                    ownerId: hotelAdminArray[4].Id
                )
            };
        }

        private static Hotel CreateHotel(int id, string name, string address, string description, string imageUrl, double size, string ownerId)
        {
            return new Hotel
            {
                Id = id,
                Name = name,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                Size = size,
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                OwnerId = ownerId
            };
        }
    }
}
