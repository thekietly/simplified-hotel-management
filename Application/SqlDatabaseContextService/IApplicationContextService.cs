using Domain.Entities;

namespace Services.SqlDatabaseContextService
{
    public interface IApplicationContextService
    {
        #region Amenity
        Task<Amenity> GetAllAmenitiesAsync();
        Task<Amenity> GetAmenityByIdAsync(int amenityId);
        Task<Amenity> AddAmenityAsync(Amenity amenity);
        Task<Amenity> DeleteAmenityAsync(Amenity amenity);
        #endregion
        #region Review
        Task<Review> GetAllReviewsByHotelIdAsync(int hotelId);
        Task<Review> GetReviewByReviewIdAsync(int reviewId);   
        Task<Review> CreateReviewAsync(Review review);
        Task<Review> DeleteReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        #endregion
    }
}
