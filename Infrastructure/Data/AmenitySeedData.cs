
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class AmenitySeedData
    {
        public static IEnumerable<Amenity> GetAmenities()
        {
            return new List<Amenity> 
            {
                new Amenity
                {
                    Id = 1,
                    Name = "Wifi",
                    Description = "Standard wifi service",
                    AmenityType = AmenityType.Both
                },
                new Amenity
                {
                    Id = 2,
                    Name = "TV",
                    Description = "Standard TV service",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 3,
                    Name = "Air conditioning",
                    Description = "Standard air conditioning",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 4,
                    Name = "Mini bar",
                    Description = "Standard mini bar",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 5,
                    Name = "Parking",
                    Description = "Standard parking lot",
                    AmenityType = AmenityType.Hotel
                },
                new Amenity
                {
                    Id = 6,
                    Name = "Restaurant",
                    Description = "Standard breakfast",
                    AmenityType = AmenityType.Hotel
                },
                new Amenity
                {
                    Id = 7,
                    Name = "Taxi to airport",
                    Description = "Travelling services",
                    AmenityType = AmenityType.Hotel
                },
                // New Amenities
                new Amenity
                {
                    Id = 8,
                    Name = "Shower",
                    Description = "Standard shower facilities",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 9,
                    Name = "Accessibility",
                    Description = "Accessibility features",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 10,
                    Name = "Close-caption TV",
                    Description = "Close-caption TV for accessibility",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 11,
                    Name = "Kitchen",
                    Description = "Kitchen facilities",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 12,
                    Name = "Electric kettle",
                    Description = "Electric kettle in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 13,
                    Name = "Hair dryer",
                    Description = "Hair dryer in the bathroom",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 14,
                    Name = "Mirror",
                    Description = "Standard mirror",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 15,
                    Name = "Private bathroom",
                    Description = "Private bathroom in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 16,
                    Name = "Toiletries",
                    Description = "Standard toiletries",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 17,
                    Name = "Towels",
                    Description = "Fresh towels provided",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 18,
                    Name = "Free Wi-Fi in all rooms",
                    Description = "Free Wi-Fi available in all rooms",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 19,
                    Name = "Radio",
                    Description = "Radio in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 20,
                    Name = "Satellite/cable channels",
                    Description = "Satellite/cable TV channels available",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 21,
                    Name = "Telephone",
                    Description = "Telephone in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 22,
                    Name = "Adapter",
                    Description = "Power adapter available",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 23,
                    Name = "Alarm clock",
                    Description = "Alarm clock in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 24,
                    Name = "Blackout curtains",
                    Description = "Blackout curtains for better sleep",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 25,
                    Name = "Heating",
                    Description = "Room heating available",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 26,
                    Name = "Linens",
                    Description = "Fresh linens provided",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 27,
                    Name = "Sleep comfort items",
                    Description = "Sleep comfort items provided",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 28,
                    Name = "Wake-up service",
                    Description = "Wake-up service available",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 29,
                    Name = "Coffee/tea maker",
                    Description = "Coffee/tea maker in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 30,
                    Name = "Refrigerator",
                    Description = "Refrigerator in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 31,
                    Name = "Daily housekeeping",
                    Description = "Daily housekeeping services",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 32,
                    Name = "Carpeting",
                    Description = "Carpeting in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 33,
                    Name = "Desk",
                    Description = "Desk in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 34,
                    Name = "Seating area",
                    Description = "Seating area in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 35,
                    Name = "Trash cans",
                    Description = "Trash cans in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 36,
                    Name = "Window",
                    Description = "Window in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 37,
                    Name = "Closet",
                    Description = "Closet in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 38,
                    Name = "Clothes rack",
                    Description = "Clothes rack in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 39,
                    Name = "Ironing facilities",
                    Description = "Ironing facilities in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 40,
                    Name = "Baby cot (upon request)",
                    Description = "Baby cot available upon request",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 41,
                    Name = "Accessible by elevator",
                    Description = "Accessibility by elevator",
                    AmenityType = AmenityType.Hotel
                },
                new Amenity
                {
                    Id = 42,
                    Name = "Accessible by stairs",
                    Description = "Accessibility by stairs",
                    AmenityType = AmenityType.Hotel
                },
                new Amenity
                {
                    Id = 43,
                    Name = "In-room safe box",
                    Description = "In-room safe box for valuables",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 44,
                    Name = "Locker",
                    Description = "Locker for guest's personal items",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 45,
                    Name = "Safety/security feature",
                    Description = "Safety/security feature available in the room",
                    AmenityType = AmenityType.Room
                },
                new Amenity
                {
                    Id = 46,
                    Name = "Smoke detector",
                    Description = "Smoke detector in the room",
                    AmenityType = AmenityType.Room
                }
            };
        }
    }
}
