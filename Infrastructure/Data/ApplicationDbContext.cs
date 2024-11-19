using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
                BedType = BedType.Double,
                RoomSize = 200
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
                BedType = BedType.Double,
                RoomSize = 200
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
                BedType = BedType.Double,
                RoomSize = 200
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
                BedType = BedType.Double,
                RoomSize = 200
            }
            );
            // Initializing data for the model - Amenity
            modelBuilder.Entity<Amenity>().HasData(new Amenity
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