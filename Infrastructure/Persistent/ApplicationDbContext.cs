﻿using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent
{
    public class ApplicationDbContext : IdentityDbContext
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
        //public DbSet<User> Users { get; set; }
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

            // booking - identity user connection
            modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>().HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Review>().HasOne(r => r.Hotel).WithMany().HasForeignKey(r => r.HotelId).OnDelete(DeleteBehavior.Restrict);

            // Seed data for hotels and related entities

            var hotelUsers = UserSeedData.GetHotelAdmins().ToList();
            modelBuilder.Entity<IdentityUser>().HasData(hotelUsers);
            modelBuilder.Entity<NormalUser>().HasData(NormalUserSeedData.GetNormalUsers());
            var hotels = HotelSeedData.GetHotels(hotelUsers).ToList();
            modelBuilder.Entity<Hotel>().HasData(hotels);
            modelBuilder.Entity<Review>().HasData(ReviewSeedData.GetReviews(hotels, (List<NormalUser>)NormalUserSeedData.GetNormalUsers()));
            
            
            modelBuilder.Entity<HotelImageGallery>().HasData(HotelImageGallerySeedData.GetHotelImageGalleries());

            modelBuilder.Entity<HotelRoom>().HasData(HotelRoomSeedData.GetHotelRooms());

            modelBuilder.Entity<Amenity>().HasData(AmenitySeedData.GetAmenities());

            modelBuilder.Entity<RoomAmenity>().HasData(RoomAmenitySeedData.GetRoomAmenities());

            modelBuilder.Entity<HotelAmenity>().HasData(HotelAmenitySeedData.GetHotelAmenities());

            modelBuilder.Entity<HotelRoomImageGallery>().HasData(HotelRoomImageGallerySeedData.GetHotelRoomImageGalleries());

        }
    }
}