
using Application.Common.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(_db);
        }
        // Save changes to the database one by one.
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
