using Domain.Entities;

namespace Services.SqlDatabaseContextService
{
    public interface IApplicationFacilityContextService
    {
        #region Amenity
        Task<ICollection<Amenity>> GetAllAmenitiesAsync();
        Task<Amenity?> GetAmenityByIdAsync(int amenityId);
        Task<CreateResult> AddAmenityAsync(Amenity amenity);
        Task<DeleteResult> DeleteAmenityAsync(ICollection<int> amenityIds);
        #endregion
        #region Review
        Task<PagedResult<Review>> GetAllReviewsByHotelIdAsync(int hotelId, int skip, int take);
        Task<Review?> GetReviewByReviewIdAsync(int reviewId);   
        Task<CreateResult> CreateReviewAsync(Review review);
        Task<DeleteResult> DeleteReviewAsync(int reviewId);
        Task<UpdateResult> UpdateReviewAsync(Review review);
        #endregion
    }
}
