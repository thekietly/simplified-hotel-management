using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Data
{
    public static class UserSeedData
    {
        public static IEnumerable<IdentityUser> GetHotelAdmins()
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var admin1 = new IdentityUser
            {
                Id = "40ee2611-abbd-479a-9bec-eb392733cc37",
                UserName = "admin1@hotel.com",
                Email = "admin1@hotel.com",
                NormalizedUserName = "ADMIN1@HOTEL.COM",
                NormalizedEmail = "ADMIN1@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin1.PasswordHash = passwordHasher.HashPassword(admin1, "Admin1Password!");

            var admin2 = new IdentityUser
            {
                Id = "0224a454-380a-4edb-9883-1aae7104aee7",
                UserName = "admin2@hotel.com",
                Email = "admin2@hotel.com",
                NormalizedUserName = "ADMIN2@HOTEL.COM",
                NormalizedEmail = "ADMIN2@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin2.PasswordHash = passwordHasher.HashPassword(admin2, "Admin2Password!");

            var admin3 = new IdentityUser
            {
                Id = "3a1b2c3d-4e5f-6789-abcd-ef0123456789",
                UserName = "admin3@hotel.com",
                Email = "admin3@hotel.com",
                NormalizedUserName = "ADMIN3@HOTEL.COM",
                NormalizedEmail = "ADMIN3@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin3.PasswordHash = passwordHasher.HashPassword(admin3, "Admin3Password!");

            var admin4 = new IdentityUser
            {
                Id = "4b5c6d7e-8f90-1234-abcd-ef5678901234",
                UserName = "admin4@hotel.com",
                Email = "admin4@hotel.com",
                NormalizedUserName = "ADMIN4@HOTEL.COM",
                NormalizedEmail = "ADMIN4@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin4.PasswordHash = passwordHasher.HashPassword(admin4, "Admin4Password!");

            var admin5 = new IdentityUser
            {
                Id = "5c6d7e8f-9012-3456-abcd-ef6789012345",
                UserName = "admin5@hotel.com",
                Email = "admin5@hotel.com",
                NormalizedUserName = "ADMIN5@HOTEL.COM",
                NormalizedEmail = "ADMIN5@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin5.PasswordHash = passwordHasher.HashPassword(admin5, "Admin5Password!");

            return new List<IdentityUser> { admin1, admin2, admin3, admin4, admin5 };
        }
    }
}
