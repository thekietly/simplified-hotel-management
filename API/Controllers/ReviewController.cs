using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/hotels/{hotelId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private const int DefaultNumberOfReviewsPerPage = 10;
        private readonly IApplicationFacilityContextService generalQueriesDatabase;
        private readonly ILogger<ReviewController> logger;

        public ReviewController(IApplicationFacilityContextService generalQueriesDatabase, ILogger<ReviewController> logger)
        {
            this.generalQueriesDatabase = generalQueriesDatabase;
            this.logger = logger;
        }
        [HttpGet(Name = "GetAllReviewsByHotelId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllReviewsAsync(int hotelId, int skip = 0, int take = DefaultNumberOfReviewsPerPage )
        {
            try 
            {
                var reviews = await this.generalQueriesDatabase.GetAllReviewsByHotelIdAsync( hotelId, skip, take );
                if ( reviews == null ) 
                    return NotFound();
                return Ok( reviews );
            } catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled exception from ReviewController.GetAllReviewsAsync");
                return Problem("Unable to get all reviews from this hotel id");
            }
        }
        [HttpGet("{reviewId}", Name = "GetReviewByHotelIdAndReviewId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
        public async Task<IActionResult> GetAsync(int hotelId, int reviewId)
        {
            try 
            {
                var review = await this.generalQueriesDatabase.GetReviewByReviewIdAndHotelIdAsync ( hotelId, reviewId );
                if ( review == null )
                    return NotFound();
                return Ok( review );
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from ReviewController.GetAsync");
                return Problem("Unable to get review by this hotel id & review id");
            }
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReviewAsync([FromBody] Review review) 
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
                var newReview = await this.generalQueriesDatabase.CreateReviewAsync (review);
                return CreatedAtRoute("GetReviewByHotelIdAndReviewId", new {id = newReview.NewId}, review);
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from ReviewController.CreateReviewAsync");
                return Problem("Unable to create review");
            }    
        }
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteAsync(int hotelId, int reviewId) 
        {
            try
            {
                var review = await this.generalQueriesDatabase.GetReviewByReviewIdAndHotelIdAsync(hotelId, reviewId);
                if (review == null)
                    return NotFound();
                await this.generalQueriesDatabase.DeleteReviewAsync(reviewId);
                return Ok();
            }
            catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from ReviewController.DeleteAsync");
                return Problem("Unable to delete this review");
            }
        }
    }
}
