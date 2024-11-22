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


    }
}
