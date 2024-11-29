using Domain.Entities;
using Application.Common.Interface;
using Infrastructure.Data;
namespace Infrastructure.Repository
{
    public class HotelImageGalleryRepository : Repository<HotelImageGallery>, IHotelImageGalleryRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelImageGalleryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
    {
    }
}
