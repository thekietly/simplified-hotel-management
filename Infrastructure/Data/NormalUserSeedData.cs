using Domain.Entities;

namespace Infrastructure.Data
{
    public static class NormalUserSeedData
    {
        public static IEnumerable<NormalUser> GetNormalUsers()
        {
            return new List<NormalUser>
            {
                new NormalUser
                {
                    Id = "1a2b3c4d-5e6f-7890-abcd-ef0123456789",
                    DisplayName = "John Doe"
                },
                new NormalUser
                {
                    Id = "2b3c4d5e-6f78-9012-abcd-ef2345678901",
                    DisplayName = "Jane Smith"
                },
                new NormalUser
                {
                    Id = "3c4d5e6f-7890-1234-abcd-ef3456789012",
                    DisplayName = "Alice Johnson"
                },
                new NormalUser
                {
                    Id = "4d5e6f78-9012-3456-abcd-ef4567890123",
                    DisplayName = "Bob Brown"
                },
                new NormalUser
                {
                    Id = "5e6f7890-1234-5678-abcd-ef5678901234",
                    DisplayName = "Charlie Davis"
                }
            };
        }
    }
}

