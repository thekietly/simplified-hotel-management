
using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }
    }
}
