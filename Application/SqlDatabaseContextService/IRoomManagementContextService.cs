using Domain.Entities;
namespace Services.SqlDatabaseContextService
{
    public interface IRoomManagementContextService
    {
        #region Hotel Room
        Task<HotelRoom?> GetRoomByIdAsync(int roomId);
        Task<PagedResult<HotelRoom>> GetAllRoomsAsync(int hotelId, int skip, int take);
        Task<CreateResult> CreateRoomAsync(HotelRoom hotelRoom);
        Task<UpdateResult> UpdateRoomAsync(HotelRoom hotelRoom);
        Task<DeleteResult> DeleteRoomAsync(int roomId);
        Task<ICollection<RoomAmenity>> GetAllRoomAmenitiesAsync(int roomId);
        Task<ICollection<CreateResult>> AddAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities);
        Task<DeleteResult> DeleteAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities);
        Task<ICollection<HotelRoomImageGallery>> GetAllRoomImagesByIdAsync(int roomId);
        Task<ICollection<CreateResult>> AddRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries);
        Task<DeleteResult> DeleteRoomImagesByIdAsync(ICollection<int> imageIds);
        #endregion
    }
}
