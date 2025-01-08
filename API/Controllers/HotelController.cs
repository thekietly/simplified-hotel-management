using AutoMapper.Internal;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public const int DefaultNumberOfHotelsPerPage = 5;
        private readonly IHotelManagementContextService hotelRepository;
        private readonly ILogger<HotelController> logger;
        public HotelController(IHotelManagementContextService hotelRepository, ILogger<HotelController> logger)
        {
            this.hotelRepository = hotelRepository;
            this.logger = logger;
        }

        [HttpGet("{hotelId}", Name = "GetHotelById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int hotelId)
        {
            try 
            {
                var hotel = await this.hotelRepository.GetHotelByIdAsync(hotelId);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            } catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from HotelController.GetAsync");
                return Problem("Unable to GET the hotel");
            }
        }

        [HttpGet(Name = "GetAllHotels")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Hotel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(int skip = 0, int take = DefaultNumberOfHotelsPerPage)
        {
            try
            {
                var hotels = await this.hotelRepository.GetAllHotelsAsync(skip, take);
                return Ok(hotels);
            } catch (Exception ex) 
            {
                logger.LogError(ex, "Unhandled exception from HotelController.GetAllAsync");
                return Problem("Unable to GetAll these hotels");
            }
        }

        [HttpPost(Name = "CreateHotel")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        public async Task<IActionResult> CreateAsync([FromBody] Hotel hotel)
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
                var newHotelResult = await this.hotelRepository.CreateHotelAsync(hotel);
                return CreatedAtRoute("GetHotelById", new { hotelId = newHotelResult.NewId}, hotel);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelController.CreateAsync");
                return Problem("Unable to Create this hotel");
            }
            
        }

        [HttpPut("{hotelId}", Name = "UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int hotelId, [FromBody] Hotel updatedHotel)
        {
            try {
                var hotelToBeUpdated = await this.hotelRepository.GetHotelByIdAsync(hotelId);
                if (hotelToBeUpdated == null)
                    return NotFound();

                if (!ModelState.IsValid)
                {
                    return BadRequest(new UpdateResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                }
                await this.hotelRepository.UpdateHotelAsync(hotelToBeUpdated);

                return Accepted(hotelToBeUpdated);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelController.UpdateAsync");
                return Problem("Unable to Update this hotel");
            }
            
        }

        [HttpDelete("{hotelId}", Name = "DeleteHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int hotelId)
        {
            try 
            {
                var hotel = await this.hotelRepository.GetHotelByIdAsync(hotelId);
                if (hotel == null)
                    return NotFound();

                await this.hotelRepository.DeleteHotelAsync(hotelId);
                return Ok();
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelController.DeleteAsync");
                return Problem("Unable to Delete this hotel");
            } 
            
        }

    }
}
