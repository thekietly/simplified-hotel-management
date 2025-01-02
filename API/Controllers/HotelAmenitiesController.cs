using API.Dtos.AmenityDto;
using API.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/hotels/{hotelId}/amenities")]
    [ApiController]
    public class HotelAmenitiesController : ControllerBase
    {
        private readonly IHotelManagementContextService hotelRepository;
        private readonly ILogger logger;
        public HotelAmenitiesController(IHotelManagementContextService hotelRepository, ILogger logger) 
        {
            this.hotelRepository = hotelRepository;
            this.logger = logger;
        }
        [HttpGet(Name = "GetAllAmenities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<HotelAmenity>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(int hotelId) 
        {
            try 
            {
                var amenities = await this.hotelRepository.GetAllHotelAmenitiesAsync(hotelId);
                if (amenities == null) 
                {
                    return NotFound();
                }
                return Ok(amenities);
                    
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelAmenitiesController.GetAllAsync");
                return Problem("Unable to GetAll the amenities by this hotel id");
            }
        }
        [HttpPost("AddAmenitiesToHotelId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ICollection<HotelAmenity>))]
        public async Task<IActionResult> AddAmenitiesAsync(int hotelId, [FromBody] AmenityDto hotelAmenityDto) 
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                }
                // check if these ids are valid
                var invalidIds = new List<int>();
                foreach (var amenityId in hotelAmenityDto.AmenityIdList)
                {
                    var amenity = await this.hotelRepository.GetHotelAmenityById(hotelId, amenityId);
                    if (amenity == null)
                    {
                        invalidIds.Add(amenityId);
                    }
                }

                if (invalidIds.Any())
                {
                    return BadRequest(new DeleteResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ServerError("Cannot add some amenities because some of them are invalid!")
                    });
                }
                // add to database
                var results = await this.hotelRepository.AddAmenityToHotelByIdAsync(hotelId, hotelAmenityDto.AmenityIdList);
                return CreatedAtRoute("GetAllAmenities", hotelId);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelAmenitiesController.AddAmenitiesAsync");
                return Problem("Unable to Add amenities to this hotel id");
            }
        }
        [HttpDelete(Name = "DeleteAmenitiesFromHotelId")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAmenitiesFromHotelAsync(int hotelId, [FromBody] AmenityDto hotelAmenityDto) 
        {
            try 
            {
                // hotelId = x | amenityList = [1,2,3,4,5]
                if (!ModelState.IsValid)
                    return BadRequest(new DeleteResult 
                    { 
                        Success = false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                // check if these ids are valid
                var invalidIds = new List<int>();
                foreach (var amenityId in hotelAmenityDto.AmenityIdList)
                {
                    var amenity = await this.hotelRepository.GetHotelAmenityById(hotelId, amenityId);
                    if (amenity == null)
                    {
                        invalidIds.Add(amenityId);
                    }
                }

                if (invalidIds.Any())
                {
                    return BadRequest(new DeleteResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ServerError("Cannot delete some amenities because some of them are invalid!")
                    });
                }
                await this.hotelRepository.DeleteAmenitiesFromHotelAsync(hotelId, hotelAmenityDto.AmenityIdList);
                return Ok();
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelAmenitiesController.DeleteAmenitiesFromHotelAsync");
                return Problem("Unable to delete amenities from this hotel id");
            }
            
        }
    }
}
