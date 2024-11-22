using Application.Common.Interface;
using client.Models;
using Domain.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace client.Controllers
{
    public class HotelRoomController : Controller
    {

        // database context
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelRoomController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        private async Task<List<SelectListItem>> GetHotelSelectListAsync()
        {
            var hotels = await _unitOfWork.Hotel.GetAll();
            return hotels.Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
        }
        // GET: HotelRoom
        public async Task<IActionResult> Index()
        {
            var hotelRooms = await _unitOfWork.HotelRoom.GetAll();  
            return View(hotelRooms);
        }

        // GET: HotelRoom/Update/5
        public async Task<IActionResult> Update(string roomId, int hotelId)
        {

            // Retrieve the hotel room with the given id from the database
            var hotelRoom = await _unitOfWork.HotelRoom.Get(hr => hr.RoomId == roomId && hr.HotelId == hotelId);
            // Return early if the hotel room is not found
            if (hotelRoom == null)
            {
                TempData["Error"] = "The hotel room you are trying to update does not exist.";
                return RedirectToAction("Error", "Home");
            }
            // Add the select list to the view model
            // Initialize the HotelRoom object as it can't be null
            var hotelRoomViewModel = new HotelRoomViewModel
            {
                HotelList = await GetHotelSelectListAsync(),
                HotelRoomVM = hotelRoom
            };
            
            return View(hotelRoomViewModel);
        }
        // POST: HotelRoom/Update/5
        [HttpPost]

        public async Task<IActionResult> Update(HotelRoomViewModel hotelRoomViewModel)
        {
            try
            {
                hotelRoomViewModel.HotelList = await GetHotelSelectListAsync();
                // If the hotel model is not bound to the hotel room model because it is inserted via the database then bind it again.

                if (hotelRoomViewModel.HotelRoomVM.Hotel == null) {
                    hotelRoomViewModel.HotelRoomVM.Hotel = await _unitOfWork.Hotel.Get(h => h.Id == hotelRoomViewModel.HotelRoomVM.HotelId);
                }

                // After binding the hotel model to the hotel room model, the model is supposed to be valid
                if (!ModelState.IsValid)
                {
                    return View(hotelRoomViewModel);
                }
                // User has uploaded an image
                if (hotelRoomViewModel.HotelRoomVM.Image != null)
                {
                    // Generate a new unique id + file extension to prevent duplicate file names
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotelRoomViewModel.HotelRoomVM.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"assets\img\HotelRoom");
                    // Navigate to the file path and create the file
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotelRoomViewModel.HotelRoomVM.Image.CopyTo(fileStream);
                    }
                    // Remove the old image

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        // Retrieve the file path of the old image
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, hotelRoomViewModel.HotelRoomVM.ImageUrl.TrimStart('\\'));
                        // Delete the old image
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    // Set the image URL to the file path
                    hotelRoomViewModel.HotelRoomVM.ImageUrl = @"\assets\img\HotelRoom\" + fileName;
                }
                // Add default image. 
                else
                {
                    hotelRoomViewModel.HotelRoomVM.ImageUrl = "https://pix8.agoda.net/hotelImages/2418908/-1/d97ea16b355f57cb293d11b5ce90d530.jpg?ca=8&ce=1&s=450x450";
                }
                // update hotel room in the database
                _unitOfWork.HotelRoom.Update(hotelRoomViewModel.HotelRoomVM);
                // update database
                _unitOfWork.Save();

                return RedirectToAction("Index", "HotelRoom");
            }
            catch
            {
                TempData["Error"] = "An unexpected error occurred. Please contact the IT support for additional help! Sorry for the inconvenience. :(";
                return RedirectToAction("Error" , "Home");
            }
        }

        // GET: HotelRoom/Create
        public async Task<IActionResult> Create()
        {

            // Add the select list to the view model
            // Initialize the HotelRoom object as it can't be null
            var hotelRoomViewModel = new HotelRoomViewModel
            {

                HotelList = await GetHotelSelectListAsync(),
                HotelRoomVM = new HotelRoom()
            };

            // Pass the view model to the view
            return View(hotelRoomViewModel);
        }

        // POST: HotelRoom/Create
        [HttpPost]
        public async Task<IActionResult> Create(HotelRoomViewModel hotelRoomView)
        {
            try
            {
                //TODO [Feature]: Add validation to avoid duplicate room numbers in the same hotel

                // Re-bind the hotel list to the view model
                hotelRoomView.HotelList = await GetHotelSelectListAsync();
                if (hotelRoomView.HotelRoomVM.HotelId == 0)
                {
                    ModelState.AddModelError("", "Hotel number is required");
                    return View(hotelRoomView);
                }
                // Bind the hotel model to the hotel room model based on the selected hotel ID
                hotelRoomView.HotelRoomVM.Hotel = await _unitOfWork.Hotel.Get(h => h.Id == hotelRoomView.HotelRoomVM.HotelId);

                // After binding the hotel model to the hotel room model, the model is supposed to be valid
                if (!ModelState.IsValid)
                {
                    return View(hotelRoomView);
                }
                // Check if the hotel room already exists in the database
                
                if (_unitOfWork.HotelRoom.Any(hr => hr.RoomId == hotelRoomView.HotelRoomVM.RoomId && hr.HotelId == hotelRoomView.HotelRoomVM.HotelId))
                {
                    ModelState.AddModelError("", "The hotel room already exists in the database. Consider using a different room number or a different hotel.");
                    return View(hotelRoomView);
                }
                // User has uploaded an image
                if (hotelRoomView.HotelRoomVM.Image != null)
                {
                    // Generate a new unique id + file extension to prevent duplicate file names
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotelRoomView.HotelRoomVM.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"assets\img\HotelRoom");
                    // Navigate to the file path and create the file
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotelRoomView.HotelRoomVM.Image.CopyTo(fileStream);
                    }
                    // Set the image URL to the file path
                    hotelRoomView.HotelRoomVM.ImageUrl = @"\assets\img\HotelRoom\" + fileName;
                }
                // Add default image. 
                else
                {
                    hotelRoomView.HotelRoomVM.ImageUrl = "https://pix8.agoda.net/hotelImages/2418908/-1/d97ea16b355f57cb293d11b5ce90d530.jpg?ca=8&ce=1&s=450x450";
                }

                // add hotel room from the view model to the database
                _unitOfWork.HotelRoom.Add(hotelRoomView.HotelRoomVM);
                // update database
                _unitOfWork.Save();
                // Added a pop up message to show that the hotel room has been created successfully
                TempData["Success"] = hotelRoomView.HotelRoomVM.Name + " has been created successfully.";
                return RedirectToAction("Index", "HotelRoom");
            }
            catch (Exception e){
                // If something goes wrong, return this model state with the message. Then go back to the create page.
                ModelState.AddModelError(string.Empty, "An unexpected error occurred: " + e.Message + "\nPlease contact the IT support for additional help! Sorry for the inconvenience. :(");
                return RedirectToAction("Error", "Home"); ;  
            }
        }




        // POST: HotelRoom/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string roomId, int hotelId)
        {
            try
            {
                HotelRoom hotelRoom = await _unitOfWork.HotelRoom.Get(hr => hr.HotelId == hotelId && hr.RoomId == roomId);
                // any edge case where the hotel room is not found? go directly to this page without hotel room?
                if (hotelRoom == null)
                {
                    TempData["Error"] = "The hotel room you are trying to delete does not exist.";
                    return RedirectToAction("Error", "Home");
                }
                // User has uploaded an image
                if (hotelRoom.Image != null)
                {
                    // Generate a new unique id + file extension to prevent duplicate file names
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotelRoom.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"assets\img\HotelRoom");
                    // Navigate to the file path and create the file
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotelRoom.Image.CopyTo(fileStream);
                    }
                    // Remove the old image
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        // Retrieve the file path of the old image
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, hotelRoom.ImageUrl.TrimStart('\\'));
                        // Delete the old image
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    // Set the image URL to the file path
                    hotelRoom.ImageUrl = @"\assets\img\HotelRoom\" + fileName;
                }
                // Add default image. 
                else
                {
                    hotelRoom.ImageUrl = "https://pix8.agoda.net/hotelImages/2418908/-1/d97ea16b355f57cb293d11b5ce90d530.jpg?ca=8&ce=1&s=450x450";
                }

                _unitOfWork.HotelRoom.Remove(hotelRoom);
                // TODO: Verify if the hotel room has been deleted successfully -> check affected rows
                TempData["Success"] = hotelRoom.Name + " has been deleted successfully.";
                _unitOfWork.Save();
                return RedirectToAction("Index", "HotelRoom");

            }
            catch
            { 
                // Any other edge cases or unexpected behaviour would redirect users back to error page.
                return RedirectToAction("Error", "Home"); ;
            }
        }
    }
}
