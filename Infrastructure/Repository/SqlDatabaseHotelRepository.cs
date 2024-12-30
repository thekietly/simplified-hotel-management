using Domain.Entities;
using Infrastructure.Data;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseHotelRepository : IHotelManagementContextService, IDisposable
    {
        private readonly ApplicationDbContext db;
        public SqlDatabaseHotelRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public Task<ICollection<HotelAmenity>> AddAmenityToHotelAsync(ICollection<HotelAmenity> hotelAmenities)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelImageGallery>> AddHotelImagesByIdAsync(ICollection<HotelImageGallery> hotelImageGalleries)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelAmenity>> DeleteAmenitiesFromHotelAsync(ICollection<HotelAmenity> hotelAmenities)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> DeleteHotelAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelImageGallery>> DeleteHotelImagesByIdAsync(ICollection<HotelImageGallery> hotelImageGalleries)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<HotelAmenity> GetAllHotelAmenitiesAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelImageGallery> GetAllHotelImageGalleryByIdAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetAllHotelsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotelByIdAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> UpdateHotelAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
