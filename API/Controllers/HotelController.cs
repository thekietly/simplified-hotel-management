using Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace client.Controllers
{

    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("api/hotel/{hotelId}/details")]
        [HttpGet]
        public async Task<IActionResult> GetHotelDetails(int hotelId)
        {
            var hotels = await _unitOfWork.Hotel.GetAll(include: q => q.Include(hr => hr.HotelRooms).Include(ha => ha.HotelAmenities).ThenInclude(a => a.Amenity));
            return Ok(hotels);
        }
        [Route("api/hotels/summary")]
        [HttpGet]
        public async Task<IActionResult> GetSummarisedHotelsInformation()
        {
            var hotels = await _unitOfWork.Hotel.GetAll(include: q => q.Include(hr => hr.HotelRooms).Include(ha => ha.HotelAmenities).ThenInclude(a => a.Amenity));
            return Ok(hotels);
        }
        [Route("api/hotels/full-details")]
        [HttpGet]
        public async Task<IActionResult> GetHotelsWithCompleteInformation()
        {
            var hotels = await _unitOfWork.Hotel.GetAll(include: q => q.Include(hr => hr.HotelRooms).Include(ha => ha.HotelAmenities).ThenInclude(a => a.Amenity));
            return Ok(hotels);
        }
    }
}
