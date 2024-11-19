using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;
namespace Infrastructure.Repository
{
    public class RoomAmenityRepository : Repository<RoomAmenity>, IRoomAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomAmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
