using Domain.Entities;

namespace Services.SqlDatabaseContextService
{
    // An interface that defines the basic CRUD operations
    public interface IHotelManagementContextService
    {
        #region Hotel
        Task<CreateResult> CreateHotelAsync(Hotel hotel);
        Task<Hotel?> GetHotelByIdAsync(int hotelId);
        Task<UpdateResult> UpdateHotelAsync(Hotel hotel);
        Task<DeleteResult> DeleteHotelAsync(int hotelId);
        Task<PagedResult<Hotel>> GetAllHotelsAsync(int skip, int take);
        Task<ICollection<HotelAmenity>> GetAllHotelAmenitiesAsync(int hotelId);
        Task<ICollection<CreateResult>> AddAmenityToHotelByIdAsync(ICollection<int> amenities, int hotelId);
        Task<DeleteResult> DeleteAmenitiesFromHotelAsync(ICollection<int> amenityIds, int hotelId);
        Task<ICollection<HotelImageGallery>> GetAllHotelImageGalleryByIdAsync(int hotelId);
        Task<ICollection<CreateResult>> AddHotelImagesByIdAsync(ICollection<HotelImageGallery> hotelImageGalleries);
        Task<DeleteResult> DeleteHotelImagesByIdAsync(ICollection<int> imageIds, int hotelId);
        #endregion

    }
}
