using API.Dtos.AmenityDto;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/amenities")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IApplicationFacilityContextService generalQueriesDatabase;
        private readonly ILogger<AmenityController> logger;

        public AmenityController(IApplicationFacilityContextService generalQueriesDatabase, ILogger<AmenityController> logger) 
        {
            this.generalQueriesDatabase = generalQueriesDatabase;
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllAmenities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Amenity>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync() 
        {
            try 
            {
                var amenities = await this.generalQueriesDatabase.GetAllAmenitiesAsync();
                if (amenities == null)
                {
                    return NotFound();
                }
                return Ok(amenities);
            } catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from AmenityController.GetAllAsync");
                return Problem("Unable to get all amenities");
            }
            
        }
        [HttpGet("{amenityId}", Name = "GetAmenityById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Amenity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAmenityByIdAsync(int amenityId) 
        {
            try
            {
                var amenity = await this.generalQueriesDatabase.GetAmenityByIdAsync(amenityId);
                if (amenity == null) 
                { 
                    return NotFound(); 
                }
                return Ok(amenity);
            }
            catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from AmenityController.GetAmenityByIdAsync");
                return Problem("Unable to get amenity with this id");
            }
        }
        [HttpPost(Name = "CreateAmenity")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Amenity))]
        public async Task<IActionResult> CreateAsync([FromBody] Amenity amenityModel) 
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
                var results = await this.generalQueriesDatabase.AddAmenityAsync(amenityModel);
                return CreatedAtRoute("GetAmenityById", new { amenityId = results.NewId}, amenityModel);
            } catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from AmenityController.CreateAsync");
                return Problem("Unable to create amenity");
            }    
        }
        [HttpDelete("{amenityId}", Name = "DeleteAmenity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteResult))]
        public async Task<IActionResult> DeleteAsync([FromBody] AmenityDto amenityDto) 
        {
            try 
            {
                if (!ModelState.IsValid || amenityDto.AmenityIdList != null) 
                {
                    return BadRequest(new DeleteResult 
                    {
                        Success = false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                }
                // check if these ids are valid
                var invalidIds = new List<int>();
                foreach (var amenityId in amenityDto.AmenityIdList)
                {
                    var amenity = await this.generalQueriesDatabase.GetAmenityByIdAsync(amenityId);
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

                await this.generalQueriesDatabase.DeleteAmenityAsync(amenityDto.AmenityIdList);
                return Ok();    
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from AmenityController.DeleteAsync");
                return Problem("Unable to delete these amenities");
            }
        }
     }
}
