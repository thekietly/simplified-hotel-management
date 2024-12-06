using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<HotelImageGallery> HotelImageGalleries { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // initializing data for the model - HotelRoom
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 1,
                Name = "Best Arena Hotel",
                Address = "1234, 5th Avenue, Adelaide",
                Description = "Nestled in the heart of the city, the Best Arena Hotel is a luxurious haven that combines elegance, comfort, and exceptional service. Whether you're visiting for business, leisure, or a special occasion, our hotel offers an ideal location and a wide range of amenities to ensure your stay is both memorable and relaxing.\r\n\r\nThe hotel features modern, spacious rooms designed with a blend of contemporary style and classic comfort. Each room is equipped with state-of-the-art facilities, including plush bedding, a flat-screen TV, high-speed Wi-Fi, and a fully stocked minibar. Our spacious suites offer even more comfort, with separate living areas, large windows with breathtaking views, and luxury bath products that guarantee a relaxing experience after a day of exploring or working.\r\n\r\nGuests can enjoy a variety of dining options at our on-site restaurant, which offers a diverse menu featuring both local and international cuisine. Whether you're looking for a hearty breakfast, a quick snack, or an elegant dinner, the culinary team at Best Arena Hotel ensures that every meal is a delightful experience. For those who prefer dining in privacy, room service is available 24/7.\r\n\r\nThe hotel boasts an array of amenities to cater to the needs of every guest. Our fully equipped fitness center allows you to maintain your workout routine while traveling, while our spa offers a range of treatments designed to rejuvenate and relax. Take a dip in our outdoor pool or unwind in the sauna for a complete wellness experience.\r\n\r\nFor business travelers, the Best Arena Hotel offers comprehensive meeting and event facilities. Our versatile meeting rooms are equipped with the latest technology, and our professional staff is always available to assist with event planning and coordination. Whether you're hosting a small seminar or a large conference, our hotel provides a seamless and efficient environment for all your business needs.\r\n\r\nThe Best Arena Hotel also offers a range of recreational activities to make your stay even more enjoyable. Explore the vibrant city center, located just a short walk from the hotel, or take a guided tour to discover local attractions. For those who prefer a more relaxed pace, our hotel is the perfect place to unwind and enjoy quality time with loved ones.\r\n\r\nWhether you're visiting for a short stay or an extended holiday, Best Arena Hotel promises to deliver a high standard of service, a peaceful ambiance, and an unforgettable experience. We look forward to welcoming you to our hotel, where exceptional comfort and personalized attention await.",
                ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Size = 200,
                Updated = DateTime.Now,
            },
            new Hotel
            {
                Id = 2,
                Name = "Adelaide Oasis Hotel",
                Address = "1234, 5th Avenue, Adelaide",
                Description = "Situated in the vibrant heart of Adelaide, the Adelaide Oasis Hotel offers a peaceful retreat amidst the city’s bustling atmosphere. With its modern amenities, stylish design, and exceptional service, it’s the perfect place for both business and leisure travelers seeking comfort and convenience.\r\n\r\nThe hotel features elegantly designed rooms with a focus on comfort and relaxation. Each room is equipped with premium furnishings, high-speed internet, flat-screen TVs, and minibars to ensure a comfortable stay. Whether you're staying for a few days or a longer visit, our rooms provide the perfect space to unwind after a busy day. The suites offer extra luxury, featuring expansive living areas, plush bedding, and spacious bathrooms designed with high-end finishes.\r\n\r\nDining at the Adelaide Oasis Hotel is an experience of its own. Our signature restaurant serves an extensive menu featuring fresh, locally sourced ingredients that highlight the best of Australian cuisine. From a hearty breakfast to a gourmet dinner, each dish is crafted to offer you a delightful culinary experience. For a more casual option, guests can enjoy drinks and snacks at our hotel’s lounge bar, offering a relaxing environment to socialize or unwind.\r\n\r\nFor guests seeking to stay active, the Adelaide Oasis Hotel offers a state-of-the-art fitness center with all the equipment needed to keep your exercise routine on track. After a workout, take a dip in our indoor pool or indulge in a rejuvenating spa treatment at our wellness center, designed to refresh and energize you.\r\n\r\nThe hotel also caters to business needs with fully equipped meeting rooms and event spaces. Our versatile facilities can accommodate small corporate meetings, large conferences, or private events. Our experienced event coordinators will assist you in creating a seamless experience for any gathering.\r\n\r\nJust a short walk from the hotel, you’ll find Adelaide’s cultural hubs, shopping precincts, and dining hotspots. Take time to explore the city’s top attractions, including the Adelaide Central Market, the Botanic Gardens, and the vibrant laneways filled with art, cafes, and boutiques. Whether you’re here for business or leisure, the Adelaide Oasis Hotel is perfectly positioned to help you experience all that this beautiful city has to offer.\r\n\r\nWith a focus on comfort, style, and service, Adelaide Oasis Hotel ensures that every stay is exceptional. We look forward to welcoming you to a memorable experience in the heart of Adelaide.",
                ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Size = 200,
                Updated = null
            }
            );
            // Hotel image gallery
            modelBuilder.Entity<HotelImageGallery>().HasKey(hig => new { hig.HotelId, hig.Id });
            modelBuilder.Entity<HotelImageGallery>().HasData(new HotelImageGallery
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
            });

            // Composite key - hotel id and room id allows for multiple rooms in a hotel while each room is unique.
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelId, hr.RoomId });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                HotelId = 1,
                RoomId = "101",
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double,
                BasePrice = 150,
                RoomSize = 200
            },
            new HotelRoom
            {
                HotelId = 1,
                RoomId = "102",
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double,
                BasePrice = 150,
                RoomSize = 200
            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = "101",
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double,
                BasePrice = 150,
                RoomSize = 200
            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = "102",
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://images.pexels.com/photos/3688261/pexels-photo-3688261.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double,
                BasePrice = 150,
                RoomSize = 200
            }
            );

            modelBuilder.Entity<Amenity>().HasData(
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
        );

            // Add composite key (AmenityId, HotelId, RoomId) to RoomAmenity
            // Add foreign key constraints to RoomAmenity (HotelId, RoomId) for HotelRoom and AmenityId for Amenity.
            // Purpose is to link amenities to rooms.
            modelBuilder.Entity<RoomAmenity>(entity =>
            {
                entity.HasKey(ra => new { ra.AmenityId, ra.HotelId, ra.RoomId });

                entity.HasOne(ra => ra.HotelRoom)
                    .WithMany(hr => hr.RoomAmenities)
                    .HasForeignKey(ra => new { ra.HotelId, ra.RoomId })
                    .OnDelete(DeleteBehavior.NoAction); // Change to NoAction

                entity.HasOne(ra => ra.Amenity)
                    .WithMany(a => a.RoomAmenities)
                    .HasForeignKey(ra => ra.AmenityId)
                    .OnDelete(DeleteBehavior.NoAction); // Change to NoAction
            });
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity
            {
                RoomId = "101",
                HotelId = 1,
                AmenityId = 1
            }, new RoomAmenity
            {
                RoomId = "101",
                HotelId = 1,
                AmenityId = 2
            },
            new RoomAmenity
            {
                RoomId = "101",
                HotelId = 1,
                AmenityId = 3
            },
            new RoomAmenity
            {
                RoomId = "102",
                HotelId = 1,
                AmenityId = 1
            },
            new RoomAmenity
            {
                RoomId = "102",
                HotelId = 1,
                AmenityId = 2
            },
            new RoomAmenity
            {
                RoomId = "102",
                HotelId = 1,
                AmenityId = 3
            });
            // This is the same as RoomAmenity but for HotelAmenity, purpose is to link amenities to hotels.
            modelBuilder.Entity<HotelAmenity>().HasKey(ha => new { ha.HotelId, ha.AmenityId });
            modelBuilder.Entity<HotelAmenity>().HasData(new HotelAmenity
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
            });


        }
    }
}