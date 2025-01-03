using API.Dtos.HotelImageDto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.SqlDatabaseContextService;

namespace API.Controllers
{
    [Route("api/hotels/{hotelId}/images")]
    [ApiController]
    public class HotelImageGalleryController : ControllerBase
    {
        private readonly IHotelManagementContextService hotelRepository;
        private readonly ILogger<HotelImageGalleryController> logger;
        public HotelImageGalleryController(IHotelManagementContextService hotelRepository, ILogger<HotelImageGalleryController> logger) 
        { 
            this.hotelRepository = hotelRepository;
            this.logger = logger;
        }
        [HttpGet(Name = "GetAllImages")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelImageGallery))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(int hotelId)
        {
            try
            {
                var images = await this.hotelRepository.GetAllHotelImageGalleryByIdAsync(hotelId);
                if (images == null)
                    return NotFound();
                return Ok(images);
            }
            catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelImageGalleryController.GetAllAsync");
                return Problem("Unable to get all the images from the hotel id provided");
            }
        }
        [HttpPost(Name = "AddImagesToHotel")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ICollection<CreateResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        public async Task<IActionResult> AddImagesAsync(int hotelId, [FromBody] HotelImageDto hotelImageDto) 
        {
            try
            {
                // Must have at least 1 and less than 4 images.
                if (hotelImageDto.ImageUrls.Count() > 4 || !hotelImageDto.ImageUrls.Any())
                {
                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ServerError("Must have at least 1 and less than 4 images.")
                    });
                }
                var results = await this.hotelRepository.AddHotelImagesByIdAsync(hotelId, hotelImageDto.ImageUrls);
                return CreatedAtRoute("AddImagesToHotel", new { hotelId }, results
            );
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelImageGalleryController.AddImagesAsync");
                return Problem("Unable to add images to the hotel id provided");
            }
        }
        [HttpDelete(Name = "DeleteImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteResult))]
        public async Task<IActionResult> DeleteImagesAsync( int hotelId, [FromBody] ImageDtoToBeDeleted imageDto) 
        {
            try 
            {
                // check if these ids are valid
                var invalidIds = new List<int>();
                foreach (var imageId in imageDto.imageIds)
                {
                    var image = await this.hotelRepository.GetHotelImageGalleryByIdAsync(hotelId, imageId);
                    if (image == null)
                    {
                        invalidIds.Add(imageId);
                    }
                }

                if (invalidIds.Any())
                {
                    return BadRequest(new DeleteResult
                    {
                        Success = false,
                        ErrorMessages = ModelState.ServerError("Cannot delete some images because some of them are invalid!")
                    });
                }
                await this.hotelRepository.DeleteHotelImagesByIdAsync(imageDto.imageIds,hotelId);
                return Ok();
            } catch (Exception ex) 
            {
                this.logger.LogError(ex, "Unhandled exception from HotelImageGalleryController.DeleteImagesAsync");
                return Problem("Unable to delete these images");
            }

        }
    }
}
