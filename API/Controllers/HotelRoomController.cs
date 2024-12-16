using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelRoomController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [Route("api/hotel-room/{RoomId}")]
        [HttpGet]
        public async Task<IActionResult> GetRoomDetails(int roomId) {
            var roomDetails = await _unitOfWork.HotelRoom.Get(filter: r => r.Id == roomId);
            // if not found returns 404 code
            if (roomDetails == null)
            {
                return NotFound();
            }
            return Ok(roomDetails);
        }

        [Route("api/hotel-room")]
        [HttpGet]
        public async Task<IActionResult> GetAllRooms() { 
            var allRooms = await _unitOfWork.HotelRoom.GetAll();
            return Ok(allRooms);
        }

        [Route("api/hotel-room")]
        [HttpPost]
        public Task<IActionResult> Create([FromBody] HotelRoom hotelRoom) {
            if (!ModelState.IsValid)
                return Task.FromResult<IActionResult>(BadRequest(ModelState));

            hotelRoom.CreatedDate = DateTime.UtcNow;
            hotelRoom.LastUpdated = DateTime.UtcNow;

            _unitOfWork.HotelRoom.Add(hotelRoom);
            _unitOfWork.Save();
            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetRoomDetails), new { roomId = hotelRoom.Id }, hotelRoom));
        }
        [Route("api/hotel-room/{roomId}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateHotelRoomPartial(int roomId, [FromBody] JsonPatchDocument<HotelRoom> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest("Invalid patch document.");

            // Retrieve the existing room
            var roomToBeUpdated = await _unitOfWork.HotelRoom.Get(filter: r => r.Id == roomId);

            // Return 404 if not found
            if (roomToBeUpdated == null)
                return NotFound();

            // Apply the patch
            patchDocument.ApplyTo(roomToBeUpdated);

            // Check model if it's valid now before writing to the database
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Add to the database
            roomToBeUpdated.LastUpdated = DateTime.UtcNow; 
            _unitOfWork.HotelRoom.Update(roomToBeUpdated);
            _unitOfWork.Save();

            // Return 200 as it's successfully added to the database
            return Ok(roomToBeUpdated);
        }

        [Route("api/hotel-room/{roomId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            var room = await _unitOfWork.HotelRoom.Get(filter: r => r.Id == roomId);
            if (room == null)
                return NotFound();

            _unitOfWork.HotelRoom.Remove(room);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
