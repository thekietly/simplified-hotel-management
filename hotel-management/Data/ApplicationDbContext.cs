using hotel_management.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel_management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
