using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseRoomRepository : IRoomManagementContextService, IDisposable
    {
        private readonly ApplicationDbContext database;
        public SqlDatabaseRoomRepository(ApplicationDbContext database)
        { 
            this.database = database;
        }

        public async Task<ICollection<CreateResult>> AddAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities)
        {

            database.RoomAmenities.AddRange(roomAmenities);
            await database.SaveChangesAsync();
            var results = roomAmenities.Select(ra => CreateResult.SuccessResult(ra.AmenityId)).ToList();
            return results;
        }

        public async Task<ICollection<CreateResult>> AddRoomImagesByIdAsync(ICollection<HotelRoomImageGallery> hotelRoomImageGalleries)
        {
            database.HotelRoomImageGalleries.AddRange(hotelRoomImageGalleries);
            await database.SaveChangesAsync();
            var results = hotelRoomImageGalleries.Select(ri => CreateResult.SuccessResult(ri.Id)).ToList();
            return results;
        }

        public async Task<CreateResult> CreateRoomAsync(HotelRoom hotelRoom)
        {
            database.HotelRooms.Add(hotelRoom);
            await database.SaveChangesAsync();
            return CreateResult.SuccessResult(hotelRoom.Id);
        }

        public async Task<DeleteResult> DeleteAmenitiesFromRoomAsync(ICollection<RoomAmenity> roomAmenities)
        {
            database.RemoveRange(roomAmenities);
            await database.SaveChangesAsync();
            return DeleteResult.SuccessResult();
        }

        public async Task<DeleteResult> DeleteRoomAsync(int roomId)
        {
            var room = database.HotelRooms.SingleOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                database.RemoveRange(roomId);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();
        }

        public async Task<DeleteResult> DeleteRoomImagesByIdAsync(ICollection<int> imageIds)
        {
            var images = database.HotelRoomImageGalleries
                        .Where(img => imageIds.Contains(img.Id))
                        .ToList();
            if (images != null) 
            {
                database.RemoveRange(images);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();
        }

        public void Dispose()
        {
            if (database != null) 
            {
                this.database.Dispose();
            }
        }

        public async Task<ICollection<RoomAmenity>> GetAllRoomAmenitiesAsync(int roomId)
        {
            return await this.database.RoomAmenities.AsNoTracking().Where(ra => ra.RoomId == roomId).ToListAsync();
        }

        public async Task<ICollection<HotelRoomImageGallery>> GetAllRoomImagesByIdAsync(int roomId)
        {
            return await this.database.HotelRoomImageGalleries.AsNoTracking().Where(ri => ri.RoomId == roomId).ToListAsync();
        }

        public async Task<PagedResult<HotelRoom>> GetAllRoomsAsync(int skip, int take)
        {
            var pageOfData = await this.database.HotelRooms.AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            var totalCount = await this.database.HotelRooms.CountAsync();
            return new PagedResult<HotelRoom>(pageOfData, totalCount);
        }

        public async Task<HotelRoom?> GetRoomByIdAsync(int roomId)
        {
            return await this.database.HotelRooms.AsNoTracking().Where(r => r.Id == roomId).SingleOrDefaultAsync();
        }

        public async Task<UpdateResult> UpdateRoomAsync(HotelRoom hotelRoom)
        {
            database.HotelRooms.Update(hotelRoom);
            await this.database.SaveChangesAsync();
            return UpdateResult.SuccessResult();
        }
    }
}
