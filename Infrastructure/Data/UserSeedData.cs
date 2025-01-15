
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class UserSeedData
    {
        public static IEnumerable<IdentityUser> GetHotelAdmins()
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var admin1 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin1@hotel.com",
                Email = "admin1@hotel.com",
                NormalizedUserName = "ADMIN1@HOTEL.COM",
                NormalizedEmail = "ADMIN1@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin1.PasswordHash = passwordHasher.HashPassword(admin1, "Admin1Password!");

            var admin2 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin2@hotel.com",
                Email = "admin2@hotel.com",
                NormalizedUserName = "ADMIN2@HOTEL.COM",
                NormalizedEmail = "ADMIN2@HOTEL.COM",
                EmailConfirmed = true,
            };
            admin2.PasswordHash = passwordHasher.HashPassword(admin2, "Admin2Password!");

            return new List<IdentityUser> { admin1, admin2 };

        }
        public static IEnumerable<IdentityUserRole<string>> GetUserRoles(IEnumerable<IdentityUser> users)
        {
            var userRoles = new List<IdentityUserRole<string>>();

            // Associate admin1 with the "HotelAdmin" role
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users.First(u => u.UserName == "admin1@hotel.com").Id,
                RoleId = "848dd8bd-705c-47e7-a61c-f1594c10f363"
            });

            // Associate admin2 with the "HotelAdmin" role
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users.First(u => u.UserName == "admin2@hotel.com").Id,
                RoleId = "848dd8bd-705c-47e7-a61c-f1594c10f363"
            });

            return userRoles;
        }
        public static IEnumerable<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = "848dd8bd-705c-47e7-a61c-f1594c10f363",
                        Name = UserRoles.User,
                        NormalizedName = UserRoles.User.ToUpper()
                    },
                    new IdentityRole
                    {
                        Id = "94f3c9c6-9a3d-4d2d-bf1c-8f3f51275a3f",
                        Name = UserRoles.HotelAdmin,
                        NormalizedName = UserRoles.HotelAdmin.ToUpper()
                    }
                };
        }
    }
}
