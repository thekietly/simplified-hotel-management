
using Application.Common.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public IHotelRoomRepository HotelRoom { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(_db);
            HotelRoom = new HotelRoomRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
