using Domain.Entities;
using Application.Common.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class HotelAmenityRepository : Repository<HotelAmenity>, IHotelAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelAmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
