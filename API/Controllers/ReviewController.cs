using Application.Common.Interface;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReviews([FromQuery] int hotelId, [FromQuery] string type="overall") 
        {
            // Check if the request has hotel id
            if (hotelId <= 0)
            {
                return BadRequest("Hotel ID is required.");
            }
            var reviews = await _unitOfWork.Review.GetAll(filter: r => r.HotelId == hotelId);
            var overallReviewDto = reviews.ToOverallReviewDto();
            return Ok(overallReviewDto);
        }
    }
}
