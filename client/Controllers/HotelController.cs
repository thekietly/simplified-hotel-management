using Application.Common.Interface;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class HotelController : Controller
    {
        // giving access to the hotel database collection via the IHotelRepository interface
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            // Program.cs will inject the IHotelRepository into the HotelController
            // Logic in the HotelRepository class will be executed
            _unitOfWork = unitOfWork;

            // IWebHostEnvironment is to work with the file system on the webserver.
            _hostEnvironment = webHostEnvironment;
        }
        // Get: /Hotel
        public async Task<IActionResult> Index()
        {
            // Ultilize the GetAll method from the IHotelRepository interface to get all hotels
            var hotels = await _unitOfWork.Hotel.GetAll();
            return View(hotels);
        }

        // Get: /Hotel/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        /// <summary>
        /// Handles the creation of a new hotel and adds it to the database.
        /// </summary>
        /// <param name="hotel">The hotel entity to create.</param>
        /// <returns>Redirects to the Index view if successful; otherwise, returns the Create view with validation errors.</returns>

        public IActionResult Create(Hotel hotel)
        {
            try {
                if (hotel.Name == hotel.Description)
                {
                    // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                    ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
                }
                // if not valid
                if (!ModelState.IsValid)
                {
                    return View(hotel);
                }

                // Check if the hotel name already exists in the database
                
                if (_unitOfWork.Hotel.Exists(hotel))
                {
                    // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                    ModelState.AddModelError("Name", "A hotel with the same name already exists.");
                    return View(hotel);
                }
                // User has uploaded an image
                if (hotel.Image != null)
                {
                    // Retrieve the file path 
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, @"assets\img\Hotel");
                    // Navigate to the file path and create the file
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }
                    // Set the image URL to the file path
                    hotel.ImageUrl = @"\assets\img\Hotel\"+ fileName;
                }
                // Add default image. 
                else { 
                    hotel.ImageUrl = "https://pix8.agoda.net/hotelImages/2418908/-1/d97ea16b355f57cb293d11b5ce90d530.jpg?ca=8&ce=1&s=450x450";
                }

                // if user inputs are valid then add hotel room to database
                _unitOfWork.Hotel.Add(hotel);
                // update database
                _unitOfWork.Save();
                return RedirectToAction("Index", "Hotel"); 

            } catch {
                return RedirectToAction("Error", "Home");
            }
            
        }
        // Get: /Hotel/Update/{id}
        /*
         Purposes of Update method:
        1. Retrieve the hotel room with the given id from the database.
        2. If the hotel room is not found, return a 404 Not Found response.
        3. If the hotel room is found, return a view with the hotel room as the model.
         */
        public async Task<IActionResult> Update(int? id) { 

            Hotel hotel = await _unitOfWork.Hotel.Get(h => h.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotel == null)
            {
                TempData["Error"] = "The hotel room you are trying to update does not exist.";
                return RedirectToAction("Error", "Home");
            }
            return View(hotel);
        }

        [HttpPost]
        // Post: /Hotel/Update/{id}
        public IActionResult Update(Hotel hotel)
        {
            if (hotel.Name == hotel.Description)
            {
                // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
            }
            // if model is not entered correctly return view
            if (!ModelState.IsValid)
            {
                // return view with the hotel room
                return View(hotel);
            }

            // If hotel image is not null then remove the old image and add the new image
            if (hotel.Image != null)
            {
                // Generate a new unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);

                // Retrieve the file path of the new image
                string imagePath = Path.Combine(_hostEnvironment.WebRootPath, @"assets\img\Hotel");
                // Navigate to the file path and create the file
                using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                {
                    hotel.Image.CopyTo(fileStream);
                }
                // Remove the old image

                if (!string.IsNullOrEmpty(fileName))
                {
                    // Retrieve the file path of the old image
                    string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, hotel.ImageUrl.TrimStart('\\'));
                    // Delete the old image
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                // Set the image URL to new file path
                hotel.ImageUrl = @"\assets\img\Hotel\" + fileName;
            }

            // if user inputs are valid then update hotel room details
            _unitOfWork.Hotel.Update(hotel);
            // update database
            _unitOfWork.Save();
            return RedirectToAction("Index", "Hotel");
        }
        // Post: /Hotel
        // Delete and show the affect of the delete on the website homepage.
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {

            Hotel hotel = await _unitOfWork.Hotel.Get(h => h.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotel == null)
            {
                TempData["Error"] = "The hotel room you are trying to delete does not exist.";

                return RedirectToAction("Error", "Home");
            }

            // TODO: Delete this hotel also deletes all the hotel rooms associated with it - this hotel ought to be deleted from the database
            // Delete this hotel also deletes the image associated with it
            if (hotel.ImageUrl != null) {
                string imagePath = Path.Combine(_hostEnvironment.WebRootPath, hotel.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

            }
            _unitOfWork.Hotel.Remove(hotel);
            _unitOfWork.Save();
            TempData["Success"] = hotel.Name + " has been deleted successfully.";
            return RedirectToAction("Index", "Hotel");

        }
    }
}
