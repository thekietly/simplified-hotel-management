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
                RoomId = 101,
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Price = 90,
                Name = "Standard Room"
            },
            new HotelRoom
            {
                HotelId = 1,
                RoomId = 102,
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Price = 90,
                Name = "Standard Room"
            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = 101,
                SpecialDetails = "Room 101 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Price = 90,
                Name = "Standard Room"

            },
            new HotelRoom
            {
                HotelId = 2,
                RoomId = 102,
                SpecialDetails = "Room 102 is a standard room with a view of the city.",
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                Occupancy = 2,
                Beds = 2,
                Price = 90,
                Name = "Standard Room"
            }
            );



        }
    }
}
