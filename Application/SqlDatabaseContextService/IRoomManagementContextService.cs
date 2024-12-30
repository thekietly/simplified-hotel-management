using Domain.Entities;
namespace Services.SqlDatabaseContextService
{
    public interface IRoomManagementContextService
    {
        #region Hotel Room
        Task<HotelRoom> GetRoomByIdAsync(int roomId);
        Task<HotelRoom> GetAllRoomsAsync();
        Task<HotelRoom> CreateRoomAsync(HotelRoom hotelRoom);
        Task<HotelRoom> UpdateRoomAsync(HotelRoom hotelRoom);
        Task<HotelRoom> DeleteRoomAsync(int roomId);
        Task<RoomAmenity> GetAllRoomAmenitiesAsync(int roomId);
        Task<ICollection<RoomAmenity>> AddAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities);
        Task<ICollection<RoomAmenity>> DeleteAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities);
        Task<HotelRoomImageGallery> GetAllRoomImagesByIdAsync(int roomId);
        Task<ICollection<HotelRoomImageGallery>> AddRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries);
        Task<ICollection<HotelRoomImageGallery>> DeleteRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries);
        #endregion
    }
}
