using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AmenityController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var amenities = await _unitOfWork.Amenity.GetAll();
            if (amenities == null) 
            {
                return NotFound();
            }
            return Ok(amenities);
        }
        [HttpGet("{amenityId}")]
        public async Task<IActionResult> Get(int amenityId) 
        {
            if (amenityId <= 0) 
            {
                return BadRequest("Invalid amenity id!");
            }
            var amenity = await _unitOfWork.Amenity.Get(filter: a => a.Id == amenityId);
            if (amenity == null) 
            {
                return NotFound("This record does not exist!");
            }
            return Ok(amenity);
        }
        [HttpPost]
        public Task<IActionResult> Create([FromBody] Amenity amenityModel) 
        {
            if (!ModelState.IsValid) 
            {
                return Task.FromResult<IActionResult>(BadRequest(ModelState));
            }
            _unitOfWork.Amenity.Add(amenityModel);
            _unitOfWork.Save();
            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(Get), new { amenityId = amenityModel.Id}, amenityModel));
        }
        [HttpDelete("{amenityId}")]
        public async Task<IActionResult> Delete(int amenityId) 
        {
            if (amenityId <= 0) 
            {
                return BadRequest("Invalid amenity id!");
            }
            var amenity = await _unitOfWork.Amenity.Get(filter: a => a.Id == amenityId);
            if (amenity == null) 
            {
                return NotFound("This record does not exist!");
            }
            _unitOfWork.Amenity.Remove(amenity);
            _unitOfWork.Save();
            return Ok();
        }
     }
}
