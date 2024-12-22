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
            if (type.Equals("overall", StringComparison.OrdinalIgnoreCase))
            {
                var reviews = await _unitOfWork.Review.GetAll(filter: r => r.HotelId == hotelId);
                var overallReviewDto = reviews.ToOverallReviewDto();
                return Ok(overallReviewDto);
            }
            else if (type.Equals("user", StringComparison.OrdinalIgnoreCase)) 
            {
                var reviews = await _unitOfWork.Review.GetAll(filter: r => r.HotelId == hotelId, include: q => q.Include(u => u.User));
                var overallReviewDto = reviews.Select(r => r.ToUserReviewDto()).ToList();
                return Ok(overallReviewDto);
            }
            else 
            {
                return BadRequest("This type of review is not supported.");
            }
        }
    }
}
