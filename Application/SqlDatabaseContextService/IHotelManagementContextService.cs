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
        Task<HotelAmenity?> GetHotelAmenityById(int hotelId, int amenityId);
        Task<ICollection<CreateResult>> AddAmenityToHotelByIdAsync(int hotelId, ICollection<int> amenitiesIds);
        Task<DeleteResult> DeleteAmenitiesFromHotelAsync(int hotelId, ICollection<int> amenitiesIds);
        Task<ICollection<HotelImageGallery>> GetAllHotelImageGalleryByIdAsync(int hotelId);
        Task<HotelImageGallery?> GetHotelImageGalleryByIdAsync(int imageId, int hotelId);
        Task<ICollection<CreateResult>> AddHotelImagesByIdAsync(int hotelId, ICollection<string> imageUrls);
        Task<DeleteResult> DeleteHotelImagesByIdAsync(ICollection<int> imageIds, int hotelId);
        #endregion

    }
}
