using API.Dtos.RoomAmenityDto;
using API.Mappers;
using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/hotel-room/amenity")]
    [ApiController]
    public class HotelRoomAmenityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelRoomAmenityController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int roomId) 
        {
            if (roomId <= 0) 
            {
                return BadRequest("Invalid room id!");
            }
            var roomAmenities = await _unitOfWork.RoomAmenity.GetAll(filter: ra => ra.RoomId == roomId);
            if (roomAmenities == null) 
            {
                return NotFound("This record does not exist!");
            }
            return Ok(roomAmenities);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomAmenityDto roomAmenityDto) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            // validate the room id is correct
            var roomExist = _unitOfWork.HotelRoom.Any(r => r.Id == roomAmenityDto.Id);
            if (!roomExist) 
            {
                return BadRequest("Invalid room id!");
            }
            // no duplicate amenities in the request
            var duplicateAmenities = roomAmenityDto.AmenityList.GroupBy(id => id)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();
            if (duplicateAmenities.Any()) 
            {
                return BadRequest($"Duplicate amenities detected in the request: {string.Join(", ", duplicateAmenities)}");
            }
            // no duplicate amenities when adding to the database
            var roomAmenitiesDb = await _unitOfWork.RoomAmenity.GetAll(filter: ra => ra.RoomId == roomAmenityDto.Id);
            var existingAmenities = roomAmenitiesDb.Select(ra => ra.AmenityId).ToHashSet();
            var duplicateInDatabase = roomAmenityDto.AmenityList.Where(amenityId => existingAmenities.Contains(amenityId)).ToList();

            if (duplicateInDatabase.Any()) 
            {
                return BadRequest($"The room already has the following amenities: {string.Join(", ", duplicateInDatabase)}");
            }
            // now convert to a list of room amenity models
            var roomAmenities = roomAmenityDto.ToRoomAmenityList();
            _unitOfWork.RoomAmenity.AddRange(roomAmenities);
            _unitOfWork.Save();
            return Ok(roomAmenities);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RoomAmenityDto roomAmenityDto ) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest("Invalid room id or amenity id");
            }
            // validate the room id is correct
            var roomExist = _unitOfWork.HotelRoom.Any(r => r.Id == roomAmenityDto.Id);
            if (!roomExist)
            {
                return BadRequest("Invalid room id!");
            }
            // no duplicate amenities in the request
            var duplicateAmenities = roomAmenityDto.AmenityList.GroupBy(id => id)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();
            if (duplicateAmenities.Any())
            {
                return BadRequest($"Duplicate amenities detected in the request: {string.Join(", ", duplicateAmenities)}");
            }
            // checking if there's any amenity records with these ids
            var roomAmenitiesDb = await _unitOfWork.RoomAmenity.GetAll(filter: ra => ra.RoomId == roomAmenityDto.Id);
            var existingAmenities = roomAmenitiesDb.Select(ra => ra.AmenityId).ToHashSet();
            // validate the amenity ids
            var invalidAmenityIds = roomAmenityDto.AmenityList.Where(amenityId => !existingAmenities.Contains(amenityId)).ToList();
            // if an amenity id does not exist
            if (invalidAmenityIds.Any())
            {
                return BadRequest($"The room does not have the following amenities: {string.Join(", ", invalidAmenityIds)}");
            }
            // from a list of room amenities, select the ones that are in the amenity list.
            var roomAmenities = roomAmenitiesDb.Where(ra => roomAmenityDto.AmenityList.Contains(ra.AmenityId)).ToList();
            _unitOfWork.RoomAmenity.RemoveRange(roomAmenities);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
