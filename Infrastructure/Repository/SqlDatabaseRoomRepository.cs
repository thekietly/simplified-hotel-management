using Domain.Entities;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseRoomRepository : IRoomManagementContextService
    {
        private readonly ApplicationDbContext db;
        public SqlDatabaseRoomRepository(ApplicationDbContext db) 
        { 
            this.db = db;
        }
        public Task<ICollection<RoomAmenity>> AddAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelRoomImageGallery>> AddRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> CreateRoomAsync(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RoomAmenity>> DeleteAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> DeleteRoomAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelRoomImageGallery>> DeleteRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries)
        {
            throw new NotImplementedException();
        }

        public Task<RoomAmenity> GetAllRoomAmenitiesAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoomImageGallery> GetAllRoomImagesByIdAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetAllRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetRoomByIdAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> UpdateRoomAsync(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
