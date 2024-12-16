using Application.Common.Interface;
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
        [Route("api/hotel-room/{RoomId}/get-details")]
        [HttpGet]
        public async Task<IActionResult> GetRoomDetails(int roomId) {
            var roomDetails = await _unitOfWork.HotelRoom.Get(filter: r => r.Id == roomId);
            if (roomDetails == null)
            {
                return NotFound();
            }
            return Ok(roomDetails);
        }

        [Route("api/hotel-room/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllRooms() { 
            var allRooms = await _unitOfWork.HotelRoom.GetAll();
            return Ok(allRooms);
        }


    }
}
