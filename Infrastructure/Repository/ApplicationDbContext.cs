using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
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
        public DbSet<HotelRoomImageGallery> HotelRoomImageGalleries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // initializing data for the website database
            base.OnModelCreating(modelBuilder);

            // Composite key - hotel id and room id allows for multiple rooms in a hotel while each room is unique.
            modelBuilder.Entity<HotelRoom>(entity =>
            {
                // Define a unique constraint on HotelId and RoomNumber
                entity.HasIndex(hr => new { hr.HotelId, hr.RoomNumber })
                      .IsUnique();
            });

            // Add composite key (AmenityId, RoomId) to RoomAmenity
            // Add foreign key constraints to RoomAmenity RoomId for HotelRoom and AmenityId for Amenity.
            modelBuilder.Entity<RoomAmenity>(entity => { entity.HasKey(ra => new { ra.AmenityId, ra.RoomId }); });

            // This is the same as RoomAmenity but for HotelAmenity, purpose is to link amenities to hotels.
            modelBuilder.Entity<HotelAmenity>().HasKey(ha => new { ha.HotelId, ha.AmenityId });

            modelBuilder.Entity<Hotel>().HasData(HotelSeedData.GetHotels());

            modelBuilder.Entity<HotelImageGallery>().HasData(HotelImageGallerySeedData.GetHotelImageGalleries());

            modelBuilder.Entity<HotelRoom>().HasData(HotelRoomSeedData.GetHotelRooms());

            modelBuilder.Entity<Amenity>().HasData(AmenitySeedData.GetAmenities());

            modelBuilder.Entity<RoomAmenity>().HasData(RoomAmenitySeedData.GetRoomAmenities());

            modelBuilder.Entity<HotelAmenity>().HasData(HotelAmenitySeedData.GetHotelAmenities());

            modelBuilder.Entity<HotelRoomImageGallery>().HasData(HotelRoomImageGallerySeedData.GetHotelRoomImageGalleries());

            modelBuilder.Entity<Booking>().HasData(BookingSeedData.GetBookings());

            modelBuilder.Entity<User>().HasData(UserSeedData.GetUsers());

            modelBuilder.Entity<Review>().HasData(ReviewSeedData.GetReviews());
        }
    }
}