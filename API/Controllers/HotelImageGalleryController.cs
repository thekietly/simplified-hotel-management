using API.Dtos.HotelImageDto;
using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageGalleryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelImageGalleryController(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int hotelId)
        {
            if (hotelId <= 0) 
            {
                return BadRequest("Invalid hotel id!");
            }
            var hotelImages = await _unitOfWork.HotelImageGallery.GetAll(filter: hi => hi.HotelId == hotelId);
            if (!hotelImages.Any())
            {
                return BadRequest("Invalid hotel id! There is no hotel record of this id.");
            }
            return Ok(hotelImages);
        }
        [HttpPost]
        public IActionResult AddImages([FromBody] HotelImageDto hotelImageDto) 
        {
            // Must have at least 1 and less than 4 images.
            if (hotelImageDto.ImageUrls.Count() > 4 || !hotelImageDto.ImageUrls.Any()) 
            {
                return BadRequest("Invalid number of images! You need to select up to 4 images.");
            }
            var hotelImages = hotelImageDto.ImageUrls.Select(url => new HotelImageGallery 
            {
                HotelId = hotelImageDto.HotelId,
                ImageUrl = url
            }).ToList();

            _unitOfWork.HotelImageGallery.AddRange(hotelImages);
            _unitOfWork.Save();
            return Ok(hotelImages);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteImages() 
        {
        }
    }
}
