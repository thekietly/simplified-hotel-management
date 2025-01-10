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
        #endregion

        #region Room Amenities
        Task<ICollection<RoomAmenity>> GetAllRoomAmenitiesAsync(int roomId);
        Task<RoomAmenity?> GetRoomAmenityById(int roomId, int amenityId);
        Task<ICollection<CreateResult>> AddAmenitiesToRoomAsync(int roomId, ICollection<int> amenityIds);
        Task<DeleteResult> DeleteAmenitiesFromRoomAsync(int roomId, ICollection<int> amenityIds);
        #endregion

        #region Room images
        Task<ICollection<HotelRoomImageGallery>> GetAllRoomImagesByIdAsync(int roomId);
        Task<HotelRoomImageGallery?> GetRoomImageByIdAsync(int roomId, int imageId);
        Task<ICollection<CreateResult>> AddRoomImagesByIdAsync(int roomId, ICollection<string> imageUrls);
        Task<DeleteResult> DeleteRoomImagesByIdAsync(ICollection<int> imageIds, int roomId);
        #endregion
    }
}
