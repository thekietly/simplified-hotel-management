
using Application.Common.Interface;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public IHotelRoomRepository HotelRoom { get; private set; }
        public IHotelAmenityRepository HotelAmenity { get; private set; }
        public IRoomAmenityRepository RoomAmenity { get; private set; }
        public IAmenityRepository Amenity { get; private set; }
        public IHotelImageGalleryRepository HotelImageGallery { get; private set; }
        public IHotelRoomImageGalleryRepository HotelRoomImageGallery { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            // Initialize the repositories, they're all related closely to each other
            Hotel = new HotelRepository(_db);
            HotelRoom = new HotelRoomRepository(_db);
            Amenity = new AmenityRepository(_db);
            HotelAmenity = new HotelAmenityRepository(_db);
            RoomAmenity = new RoomAmenityRepository(_db);
            HotelImageGallery = new HotelImageGalleryRepository(_db);
            HotelRoomImageGallery = new HotelRoomImageGalleryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
