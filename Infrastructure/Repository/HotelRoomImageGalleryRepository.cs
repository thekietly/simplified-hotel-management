
using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class HotelRoomImageGalleryRepository : Repository<HotelRoomImageGallery>, IHotelRoomImageGalleryRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelRoomImageGalleryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
