using Domain.Entities;

namespace Services.SqlDatabaseContextService
{
    // An interface that defines the basic CRUD operations
    public interface IHotelManagementContextService
    {
        #region Hotel
        Task<Hotel> CreateHotelAsync(Hotel hotel);
        Task<Hotel> GetHotelByIdAsync(int hotelId);
        Task<Hotel> UpdateHotelAsync(Hotel hotel);
        Task<Hotel> DeleteHotelAsync(int hotelId);
        Task<Hotel> GetAllHotelsAsync();
        Task<HotelAmenity> GetAllHotelAmenitiesAsync(int hotelId);
        Task<ICollection<HotelAmenity>> AddAmenityToHotelAsync(ICollection<HotelAmenity> hotelAmenities);
        Task<ICollection<HotelAmenity>> DeleteAmenitiesFromHotelAsync(ICollection<HotelAmenity> hotelAmenities);
        Task<HotelImageGallery> GetAllHotelImageGalleryByIdAsync(int hotelId);
        Task<ICollection<HotelImageGallery>> AddHotelImagesByIdAsync(ICollection<HotelImageGallery> hotelImageGalleries);
        Task<ICollection<HotelImageGallery>> DeleteHotelImagesByIdAsync(ICollection<HotelImageGallery> hotelImageGalleries);
        #endregion

    }
}
