using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;


namespace Infrastructure.Repository
{
    public class HotelRepository :  Repository<Hotel>,IHotelRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Check if a hotel with the same name already exists
        public bool Exists(Hotel entity)
        {
            return _db.Hotels.Any(e => e.Name == entity.Name);
        }
    }
}
