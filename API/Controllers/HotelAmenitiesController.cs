using API.Dtos.HotelAmenityDto;
using API.Mappers;
using Application.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/hotel/amenity")]
    [ApiController]
    public class HotelAmenitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelAmenitiesController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int hotelId) 
        {
            if (hotelId < 0) 
            {
                return BadRequest("Invalid hotel id.");
            }
            var hotelAmenities = await _unitOfWork.HotelAmenity.GetAll(filter: ha =>ha.HotelId == hotelId);
            if (hotelAmenities == null) 
            {
                return NotFound("This hotel seems to have no amenities.");
            }
            return Ok(hotelAmenities);
        }
        [HttpPost]
        public IActionResult AddAmenitiesToHotel([FromBody] HotelAmenityDto hotelAmenityDto) 
        {
            // hotelId = x | amenityList = [1,2,3,4,5]
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Convert this dto to a list of hotel amenities
            var hotelAmenities = hotelAmenityDto.ToHotelAmenityList();
            if (hotelAmenities == null)
                return BadRequest(ModelState);
            _unitOfWork.HotelAmenity.AddRange(hotelAmenities);
            _unitOfWork.Save();
            return Ok(hotelAmenities);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAmenitiesFromHotel([FromBody] HotelAmenityDto hotelAmenityDto) 
        {
            // hotelId = x | amenityList = [1,2,3,4,5]
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Convert this dto to a list of hotel amenities
            var hotelAmenities = hotelAmenityDto.ToHotelAmenityList();
            if (hotelAmenities == null)
                return BadRequest(ModelState);
            _unitOfWork.HotelAmenity.RemoveRange(hotelAmenities);
            _unitOfWork.Save();
            return Ok(hotelAmenities);
        }
    }
}
