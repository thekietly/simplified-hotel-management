using Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace client.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _unitOfWork.Hotel.GetAll(include: q => q.Include(hr => hr.HotelRooms).Include(ha => ha.HotelAmenities).ThenInclude(a => a.Amenity));
            return Ok(hotels);
        }
    }
}
