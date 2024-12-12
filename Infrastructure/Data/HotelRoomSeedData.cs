using Domain.Entities;

namespace Infrastructure.Data
{
    public static class HotelRoomSeedData
    {
        public static IEnumerable<HotelRoom> GetHotelRooms() 
        {
            return new List<HotelRoom> 
            {
                new HotelRoom
                {
                    Id= 1,
                    HotelId = 1,
                    RoomNumber = "101",
                    SpecialDetails = "Room 101 is a standard room with a view of the city.",
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Occupancy = 2,
                    Beds = 2,
                    Name = "Standard Room",
                    RoomStatus = RoomStatus.Booked,
                    RoomType = RoomType.Standard,
                    BedType = BedType.Double,
                    BasePrice = 150,
                    RoomSize = 200
                },
                new HotelRoom
                {
                    Id = 2,
                    HotelId = 1,
                    RoomNumber = "102",
                    SpecialDetails = "Room 102 is a standard room with a view of the city.",
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Occupancy = 2,
                    Beds = 2,
                    Name = "Standard Room",
                    RoomStatus = RoomStatus.Available,
                    RoomType = RoomType.Standard,
                    BedType = BedType.Double,
                    BasePrice = 150,
                    RoomSize = 200
                },
                new HotelRoom
                {
                    Id = 3,
                    HotelId = 2,
                    RoomNumber = "101",
                    SpecialDetails = "Room 101 is a standard room with a view of the city.",
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Occupancy = 2,
                    Beds = 2,
                    Name = "Standard Room",
                    RoomStatus = RoomStatus.Available,
                    RoomType = RoomType.Standard,
                    BedType = BedType.Double,
                    BasePrice = 150,
                    RoomSize = 200
                },
                new HotelRoom
                {
                    Id = 4,
                    HotelId = 2,
                    RoomNumber = "102",
                    SpecialDetails = "Room 102 is a standard room with a view of the city.",
                    ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Occupancy = 2,
                    Beds = 2,
                    Name = "Standard Room",
                    RoomStatus = RoomStatus.Booked,
                    RoomType = RoomType.Standard,
                    BedType = BedType.Double,
                    BasePrice = 150,
                    RoomSize = 200
                }
            };
        
        }
    }
}
