using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.SqlDatabaseContextService;

namespace Infrastructure.Repository
{
    public class SqlDatabaseHotelRepository : IHotelManagementContextService, IDisposable
    {
        private readonly ApplicationDbContext database;
        public SqlDatabaseHotelRepository(ApplicationDbContext database) 
        {
            this.database = database;
        }

        public async Task<ICollection<CreateResult>> AddAmenityToHotelByIdAsync(int hotelId, ICollection<int> amenitiesIds)
        {
            var hotelAmenities = amenitiesIds.Select(amenityId => new HotelAmenity
            {
                AmenityId = amenityId,
                HotelId = hotelId
            }).ToList();
            // Add to the database
            database.AddRange(hotelAmenities);
            await database.SaveChangesAsync();
            var results = hotelAmenities.Select(ha => CreateResult.SuccessResult(ha.AmenityId)).ToList();
            return results;
        }

        public async Task<ICollection<CreateResult>> AddHotelImagesByIdAsync(int hotelId, ICollection<string> imageUrls)
        {
            var hotelImageGalleries = imageUrls.Select(url => new HotelImageGallery
            {
                HotelId = hotelId,
                ImageUrl = url
            });
            database.AddRange(hotelImageGalleries);
            await database.SaveChangesAsync();
            var results = hotelImageGalleries.Select(hotelImageGalleries => CreateResult.SuccessResult(hotelImageGalleries.Id)).ToList();
            return results;
        }

        public async Task<CreateResult> CreateHotelAsync(Hotel hotel)
        {
            database.Add(hotel);
            await database.SaveChangesAsync();
            return CreateResult.SuccessResult(hotel.Id);
        }

        public async Task<DeleteResult> DeleteAmenitiesFromHotelAsync(int hotelId, ICollection<int> amenitiesIds)
        {
            var existingHotelAmenities = this.database.HotelAmenities
            .Where(ha => ha.HotelId == hotelId && amenitiesIds.Contains(ha.AmenityId))
            .ToList();
            if (existingHotelAmenities != null) 
            {
                database.RemoveRange(existingHotelAmenities);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();
        }

        public async Task<DeleteResult> DeleteHotelAsync(int hotelId)
        {
            var existingHotel = database.Hotels.SingleOrDefault(h => h.Id == hotelId);

            if (existingHotel != null) 
            {
                database.Remove(existingHotel);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();
        }

        public async Task<DeleteResult> DeleteHotelImagesByIdAsync(ICollection<int> imageIds, int hotelId)
        {
            var existingHotelImages = this.database.HotelImageGalleries
                .Where(hi => hi.HotelId == hotelId && imageIds.Contains(hi.Id))
                .ToList();
            if (existingHotelImages != null) 
            {
                database.RemoveRange(existingHotelImages);
                await database.SaveChangesAsync();
            }
            return DeleteResult.SuccessResult();
        }

        public void Dispose()
        {
            if (this.database != null) 
            {
                this.database.Dispose();
            }
        }

        public async Task<ICollection<HotelAmenity>> GetAllHotelAmenitiesAsync(int hotelId)
        {
            return await this.database.HotelAmenities.AsNoTracking().Where(ha => ha.HotelId == hotelId).ToListAsync();
        }

        public async Task<ICollection<HotelImageGallery>> GetAllHotelImageGalleryByIdAsync(int hotelId)
        {
            return await this.database.HotelImageGalleries.AsNoTracking().Where(hi => hi.HotelId == hotelId).ToListAsync();
        }

        public async Task<PagedResult<Hotel>> GetAllHotelsAsync(int skip, int take)
        {
            // Add more includes to show the relevant data about the hotel i.e amenities/ pricing
            var pageOfData = await this.database.Hotels
                .AsNoTracking()
                .OrderByDescending(h => h.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            var totalCount = await this.database.Hotels.CountAsync();
            return new PagedResult<Hotel>(pageOfData, totalCount);
        }

        public async Task<HotelAmenity?> GetHotelAmenityById(int hotelId, int amenityId)
        {
            return await database.HotelAmenities
                .AsNoTracking()
                .Where(h => h.HotelId == hotelId && h.AmenityId == amenityId)
                .FirstOrDefaultAsync();
        }

        public async Task<Hotel?> GetHotelByIdAsync(int hotelId)
        {
            return await database.Hotels.AsNoTracking().Where(h => h.Id == hotelId).SingleOrDefaultAsync();
        }

        public async Task<HotelImageGallery?> GetHotelImageGalleryByIdAsync(int imageId, int hotelId)
        {
            return await database.HotelImageGalleries.AsNoTracking().Where(hig => hig.HotelId == hotelId && hig.Id == imageId).SingleOrDefaultAsync();
        }

        public async Task<UpdateResult> UpdateHotelAsync(Hotel hotel)
        {
            database.Update(hotel);
            await database.SaveChangesAsync();
            return UpdateResult.SuccessResult();
        }
    }
}
