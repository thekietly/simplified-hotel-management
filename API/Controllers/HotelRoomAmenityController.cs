using API.Dtos.RoomAmenityDto;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/hotels/{hotelId}/rooms/{roomId}/amenities")]
    [ApiController]
    public class HotelRoomAmenityController : ControllerBase
    {
        private readonly IRoomManagementContextService roomRepository;
        private readonly IHotelManagementContextService hotelRepository;
        private readonly ILogger logger;
        public HotelRoomAmenityController(IRoomManagementContextService roomRepository,IHotelManagementContextService hotelRepository, ILogger logger) 
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
            this.hotelRepository = hotelRepository;
        }

        [HttpGet(Name = "GetAllRoomAmenities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<RoomAmenity>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(int hotelId, int roomId) 
        {
            try 
            {   
                var hotel = await this.hotelRepository.GetHotelByIdAsync(hotelId);
                if (hotel == null) 
                {
                    return NotFound();
                }
                var room = await this.roomRepository.GetRoomByIdAsync(roomId);
                if (room == null)
                    return NotFound();
                var amenities = await this.roomRepository.GetAllRoomAmenitiesAsync(roomId);
                return Ok(amenities);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomAmenityController.GetAllAsync");
                return Problem("Unable to get all amenities for this room");
            }
        }
        [HttpPost(Name = "AddAmenitiesToRoom")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ICollection<HotelAmenity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type= typeof(CreateResult))]

        public async Task<IActionResult> AddAmenitiesToRoomAsync(int roomId, [FromBody] RoomAmenityDto roomAmenityDto) 
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
                var invalidIds = new List<int>();
                foreach (var amenityId in roomAmenityDto.AmenityList) 
                {
                    var amenity = await this.roomRepository.GetRoomAmenityById(roomId, amenityId);
                    if (amenity == null)
                    {
                        invalidIds.Add(amenityId);
                    }
                }
                if (invalidIds.Any()) 
                {
                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ServerError("Cannot add some amenities because some of the room amenities are invalid")
                    });
                }
                var results = await this.roomRepository.AddAmenitiesToRoomAsync(roomId, roomAmenityDto.AmenityList);
                return CreatedAtRoute("AddAmenitiesToRoom", new { roomId}, results);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomAmentiyController.CreateAsync");
                return Problem("Unable to add amenities to a room by this id");
            }
        }
        [HttpDelete(Name = "DeleteAmenitesFromRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int roomId, [FromBody] RoomAmenityDto roomAmenityDto ) 
        {
            try 
            {
                var room = await this.roomRepository.GetRoomByIdAsync(roomId);
                if (room == null)
                    return NotFound();
                if (!ModelState.IsValid) 
                {
                    return BadRequest(new DeleteResult 
                    {
                        Success =false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                }
                var invalidIds = new List<int>();
                foreach (var amenityId in roomAmenityDto.AmenityList)
                {
                    var amenity = await this.roomRepository.GetRoomAmenityById(roomId, amenityId);
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
                        ErrorMessages = ModelState.ServerError("Cannot delete some amenities because some of the room amenities are invalid")
                    });
                }
                await this.roomRepository.DeleteAmenitiesFromRoomAsync(roomId, roomAmenityDto.AmenityList);
                return Ok();

            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomAmenityController.DeleteAsync");
                return Problem("Unable to delete these amenities from this room id");
            }

        }
    }
}
