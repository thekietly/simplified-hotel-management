using Domain.Entities;
using Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseApplicationFacilityRepository : IApplicationFacilityContextService, IDisposable
    {
        private readonly ApplicationDbContext database;
        public SqlDatabaseApplicationFacilityRepository(ApplicationDbContext database)
        {
            this.database = database;
        }

        public async Task<CreateResult> AddAmenityAsync(Amenity amenity)
        {
            this.database.Amenities.Add(amenity);
            await this.database.SaveChangesAsync();
            return CreateResult.SuccessResult(amenity.Id);
        }

        public async Task<CreateResult> CreateReviewAsync(Review review)
        {
            this.database.Reviews.Add(review);
            await this.database.SaveChangesAsync();
            return CreateResult.SuccessResult(review.Id);
        }

        public async Task<DeleteResult> DeleteAmenityAsync(ICollection<int> amenityIds)
        {
            var amenitiesToDelete = database.Amenities
                                    .Where(a => amenityIds.Contains(a.Id))
                                    .ToList();

            if (!amenitiesToDelete.Any()) 
            {
                return DeleteResult.SuccessResult();
            }
            // Remove associations from HotelAmenities 
            var hotelAmenitiesToDelete = database.HotelAmenities
                                        .Where(ha => amenityIds.Contains(ha.AmenityId))
                                        .ToList();
            if (hotelAmenitiesToDelete.Any())
            {
                database.HotelAmenities.RemoveRange(hotelAmenitiesToDelete);
            }

            // Remove associations from RoomAmenities
            var roomAmenitiesToDelete = database.RoomAmenities
                                        .Where(ra => amenityIds.Contains(ra.AmenityId))
                                        .ToList();
            if (roomAmenitiesToDelete.Any())
            {
                database.RoomAmenities.RemoveRange(roomAmenitiesToDelete);
            }

            database.Amenities.RemoveRange(amenitiesToDelete);
            await database.SaveChangesAsync();
            return DeleteResult.SuccessResult();
        }

        public async Task<DeleteResult> DeleteReviewAsync(int reviewId)
        {
            var review = await database.Reviews.Where(r => r.Id == reviewId).SingleOrDefaultAsync();
            if (review != null)
            {
                database.Reviews.Remove(review);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();

        }

        public void Dispose()
        {
            if (database != null) 
            { 
                database.Dispose(); 
            }
        }

        public async Task<ICollection<Amenity>> GetAllAmenitiesAsync()
        {
            return await this.database.Amenities.AsNoTracking().ToListAsync();  
        }

        public async Task<PagedResult<Review>> GetAllReviewsByHotelIdAsync(int hotelId, int skip, int take)
        {
            var pageOfData = await this.database.Reviews
                .AsNoTracking()
                .Where(r => r.HotelId == hotelId)
                .OrderByDescending(r => r.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            var totalCount = await this.database.Reviews.Where(r => r.HotelId == hotelId).CountAsync();
            return new PagedResult<Review>(pageOfData, totalCount);
        }

        public async Task<Amenity?> GetAmenityByIdAsync(int amenityId)
        {
            return await this.database.Amenities.Where(a => a.Id == amenityId).SingleOrDefaultAsync();
        }

        public async Task<Review?> GetReviewByReviewIdAndHotelIdAsync(int hotelId, int reviewId)
        {
            return await this.database.Reviews.Where(r => r.Id == reviewId && r.HotelId == hotelId).SingleOrDefaultAsync();
        }

        public async Task<UpdateResult> UpdateReviewAsync(Review review)
        {
            database.Reviews.Update(review);
            await this.database.SaveChangesAsync();
            return UpdateResult.SuccessResult();
        }
    }
}
