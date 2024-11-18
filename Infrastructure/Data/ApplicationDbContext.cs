using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // initializing data for the model - HotelRoom
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 1,
                Name = "Hotel 1",
                Address = "1234, 5th Avenue, New York",
                Description = "Standard Room Description",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Size = 200,
                UpdatedBy = DateTime.Now,

            },
            new Hotel
            {
                Id = 2,
                Name = "Hotel 2",
                Address = "1234, 5th Avenue, New York",
                Description = "Standard Room Description",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Size = 200,
                UpdatedBy = null
            }

            );
            // Composite key - hotel id and room id allows for multiple rooms in a hotel while each room is unique.
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelId, hr.RoomId });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                HotelId = 1,
                RoomId = "101",
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double


            },
            new HotelRoom
            {
                HotelId = 1,
                RoomId = "102",
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double
            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = "101",
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double

            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = "102",
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Name = "Standard Room",
                RoomType = RoomType.Standard,
                BedType = BedType.Double
            }
            );
            modelBuilder.Entity<Amenity>().HasData(new Amenity
            {
                Id = 1,
                Name = "Wifi",
                Description = "Standard wifi service",
                Icon = "bi-wifi"
            },
            new Amenity
            {
                Id = 2,
                Name = "TV",
                Description = "Standard TV service",
                Icon = "bi-tv"
            },
            new Amenity
            {
                Id = 3,
                Name = "Air conditioner",
                Description = "Standard air conditioner",
                Icon = "bi-thermometer-snow"
            },
            new Amenity
            {
                Id = 4,
                Name = "Mini bar",
                Description = "Standard mini bar",
                Icon = "bi-fridge"
            },
            new Amenity
            {
                Id = 5,
                Name = "Parking",
                Description = "Standard parking lot",
                Icon = "bi-p-circle"
            },
            new Amenity
            {
                Id = 6,
                Name = "Restaurant",
                Description = "Standard breakfast",
                Icon = "bi-egg-fried"
            },
            new Amenity
            {
                Id = 7,
                Name = "Taxi to airport",
                Description = "Travelling services",
                Icon = "bi-airplane"
            }
            );

            modelBuilder.Entity<RoomAmenity>().HasKey(ra => new { ra.RoomId, ra.AmenityId });
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity
            {
                RoomId = "101",
                AmenityId = 1
            }, new RoomAmenity
            {
                RoomId = "101",
                AmenityId = 2
            },
            new RoomAmenity
            {
                RoomId = "101",
                AmenityId = 3
            },
            new RoomAmenity
            {
                RoomId = "102",
                AmenityId = 1
            },
            new RoomAmenity
            {
                RoomId = "102",
                AmenityId = 2
            },
            new RoomAmenity
            {
                RoomId = "102",
                AmenityId = 3
            });

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
