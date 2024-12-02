using Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;

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
            var hotels = await _unitOfWork.Hotel.GetAll();
            return Ok(hotels);
        }
    }
}
