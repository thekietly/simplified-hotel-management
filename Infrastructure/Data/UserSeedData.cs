
using Domain.Entities;

namespace Infrastructure.Data
{
    public static class UserSeedData
    {
        public static IEnumerable<User> GetUsers() 
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    UserRole = User.Role.Registered,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "websiteadmin@gmail.com",
                    Password = "websiteadmin123!",
                    UserRole = User.Role.WebsiteAdmin,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Email = "hoteladmin@gmail.com",
                    Password = "hoteladmin123!",
                    UserRole = User.Role.HotelAdmin,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                }
            };
        }
    }
}
