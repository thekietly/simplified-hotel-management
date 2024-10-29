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
        public DbSet<HotelRoom> HotelRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // initializing data for the model - HotelRoom
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                Id = 1,
                Name = "Standard Room",
                Description = "Standard Room Description",
                Address = "123 Main St, New York, NY 10001",
                Occupancy = 2,
                ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                price = 90,
                size = 200,
                PhoneNumber = "123-456-7890"
            });
        }
    }
}
