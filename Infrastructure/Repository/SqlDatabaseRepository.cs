using Domain.Entities;
using Infrastructure.Data;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseApplicationFacilityRepository : IApplicationFacilityContextService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        public SqlDatabaseApplicationFacilityRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<Amenity> AddAmenityAsync(Amenity amenity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> CreateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> DeleteAmenityAsync(Amenity amenity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> DeleteReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetAllAmenitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetAllReviewsByHotelIdAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetAmenityByIdAsync(int amenityId)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewByReviewIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<Review> UpdateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
