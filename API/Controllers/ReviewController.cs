using Application.Common.Interface;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

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
        public async Task<IActionResult> GetAllReviews([FromQuery] int hotelId, [FromQuery] string type = "overall")
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
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            if (reviewId <= 0) 
            {
                return BadRequest("Invalid review id");
            }
            var review= await _unitOfWork.Review.Get(filter: r => r.Id == reviewId, include: q => q.Include(u => u.User).Include(h => h.Hotel));
            if (review == null) 
            {
                return BadRequest("The review you are looking for is not existed");
            }
            return Ok(review);
        }

        [HttpPost]
        public Task<IActionResult> CreateReview([FromBody] Review review) 
        {
            if (!ModelState.IsValid) 
            {
                return Task.FromResult<IActionResult>(BadRequest(ModelState));
            }
            review.CreatedDate = DateTime.Now;
            review.LastUpdated = DateTime.Now;
            _unitOfWork.Review.Add(review);
            _unitOfWork.Save();
            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetReview), new { reviewId = review.Id }, review));
        }
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId) 
        {
            if (reviewId <= 0) 
            {
                return BadRequest("Invalid review id");
            }
            var review = await _unitOfWork.Review.Get(filter: r => r.Id == reviewId);
            if (review == null)
            {
                return NotFound();
            }
            _unitOfWork.Review.Remove(review);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
