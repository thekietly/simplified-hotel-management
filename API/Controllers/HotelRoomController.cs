using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{

    [Route("api/hotels/{hotelId}/rooms")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IRoomManagementContextService roomRepository;
        private readonly ILogger logger;
        private const int DefaultNumberOfRoomsPerPage = 5;
        public HotelRoomController(IRoomManagementContextService roomRepository, ILogger logger) {
            this.roomRepository = roomRepository;
            this.logger = logger;
        }


        [HttpGet("{roomId}", Name = "GetRoomById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelRoom))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int roomId) {
            try 
            {
                var roomDetails = await this.roomRepository.GetRoomByIdAsync(roomId);
                // if not found returns 404 code
                if (roomDetails == null)
                {
                    return NotFound();
                }
                return Ok(roomDetails);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomController.GetAsync");
                return Problem("Unable to GET the room by this id");
            }
            
        }


        [HttpGet("GetAllRooms", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<HotelRoom>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(int hotelId, int skip = 0, int take = DefaultNumberOfRoomsPerPage) {
            try 
            {
                var allRooms = await this.roomRepository.GetAllRoomsAsync(hotelId, skip, take);
                return Ok(allRooms);
            } catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomController.GetAllAsync");
                return Problem("Unable to GetAll the room");
            }
        }

        [HttpPost(Name = "CreateHotelRoom")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HotelRoom))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]

        public async Task<IActionResult> CreateAsync([FromBody] HotelRoom hotelRoom) 
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

                var newRoomResult = await this.roomRepository.CreateRoomAsync(hotelRoom);
                return CreatedAtRoute("GetRoomById", new { id = newRoomResult.NewId}, hotelRoom);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomController.CreateAsync");
                return Problem("Unable to Create the room");
            } 
        }
        [HttpPut(Name="UpdateRoom")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(HotelRoom))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody] HotelRoom hotelRoom)
        {
            try 
            {
                var existingRoom = await this.roomRepository.GetRoomByIdAsync(hotelRoom.Id);
                if (existingRoom == null)
                {
                    return NotFound();
                }
                else if (!ModelState.IsValid) 
                {
                    return BadRequest(new UpdateResult 
                    {
                        Success=false,
                        ErrorMessages = ModelState.ConvertToErrorMessages()
                    });
                }
                await this.roomRepository.UpdateRoomAsync(hotelRoom);
                return Accepted(hotelRoom);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomController.UpdateAsync");
                return Problem("Unable to Update the room");
            }
        }


        [HttpDelete("{roomId}", Name = "DeleteRoom")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int roomId)
        {
            try
            {
                var room = await this.roomRepository.GetRoomByIdAsync(roomId);
                if (room == null)
                    return NotFound();
                await this.roomRepository.DeleteRoomAsync(roomId);
                return Ok();
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelRoomController.DeleteAsync");
                return Problem("Unable to Delete the room");
            }
        }

    }
}
