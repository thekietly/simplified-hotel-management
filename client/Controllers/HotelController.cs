//using Application.Common.Interface;
//using Domain.Entities;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace client.Controllers
//{
//    public class HotelController : Controller
//    {
//        // giving access to the hotel database collection via the IHotelRepository interface
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
//        {
//            // Program.cs will inject the IHotelRepository into the HotelController
//            // Logic in the HotelRepository class will be executed
//            _unitOfWork = unitOfWork;

//            // IWebHostEnvironment is to work with the file system on the webserver.
//            _webHostEnvironment = webHostEnvironment;
//        }
//        // Get: /Hotel
//        public async Task<IActionResult> Index()
//        {
//            // Ultilize the GetAll method from the IHotelRepository interface to get all hotels
//            var hotels = await _unitOfWork.Hotel.GetAll();
//            return View(hotels);
//        }

//        // Get: /Hotel/Create
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        /// <summary>
//        /// Handles the creation of a new hotel and adds it to the database.
//        /// </summary>
//        /// <param name="hotel">The hotel entity to create.</param>
//        /// <returns>Redirects to the Index view if successful; otherwise, returns the Create view with validation errors.</returns>
//        public IActionResult Create(Hotel hotel)
//        {
//            try
//            {
//                if (hotel.Name == hotel.Description)
//                {
//                    ModelState.AddModelError("Name", "Please be creative! The hotel's name cannot be the same as its description.");
//                }

//                if (!ModelState.IsValid)
//                {
//                    return View(hotel);
//                }

//                if (_unitOfWork.Hotel.Any(h => h.Name == hotel.Name))
//                {
//                    ModelState.AddModelError("Name", "A hotel with the same name already exists.");
//                    return View(hotel);
//                }

//                // Process uploaded image
//                if (hotel.Image != null)
//                {
//                    hotel.ImageUrl=  UploadImageAsync(hotel.Image).Result;
//                }
//                // Add hotel to the database
//                _unitOfWork.Hotel.Add(hotel);
//                _unitOfWork.Save();
//                return RedirectToAction("Index", "Hotel");
//            }
//            catch
//            {
//                return RedirectToAction("Error", "Home");
//            }
//        }

//        // GET: /Hotel/Details/{id}
//        /*
//         Display the details of the hotel room with the given id.
//         Along with amenities, hotel rooms, and other details.
//         It will also display a table of all the hotel rooms with prices and other details.
         
//         */
//        public async Task<IActionResult> Details(int? id)
//        {
//            Hotel hotel = await _unitOfWork.Hotel.Get(h => h.Id == id, include: q => q.Include(hr => hr.HotelRooms).Include(ha => ha.HotelAmenities).ThenInclude(a => a.Amenity));
//            // any edge case where the hotel room is not found? go directly to this page without hotel room?
//            if (hotel == null)
//            {
//                TempData["Error"] = "The hotel room you are trying to update does not exist.";
//                return RedirectToAction("Error", "Home");
//            }
//            return View(hotel);
//        }

//        // Get: /Hotel/Update/{id}
//        /*
//         Purposes of Update method:
//        1. Retrieve the hotel room with the given id from the database.
//        2. If the hotel room is not found, return a 404 Not Found response.
//        3. If the hotel room is found, return a view with the hotel room as the model.
//         */
//        public async Task<IActionResult> Update(int? id) { 

//            Hotel hotel = await _unitOfWork.Hotel.Get(h => h.Id == id);
//            // any edge case where the hotel room is not found? go directly to this page without hotel room?
//            if (hotel == null)
//            {
//                TempData["Error"] = "The hotel room you are trying to update does not exist.";
//                return RedirectToAction("Error", "Home");
//            }
//            return View(hotel);
//        }

//        [HttpPost]
//        // Post: /Hotel/Update/{id}
//        public IActionResult Update(Hotel hotel)
//        {
//            if (hotel.Name == hotel.Description)
//            {
//                // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
//                ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
//            }
//            // if model is not entered correctly return view
//            if (!ModelState.IsValid)
//            {
//                // return view with the hotel room
//                return View(hotel);
//            }
//            // Process uploaded images
//            if (hotel.Image != null)
//            {

//                if (hotel.ImageUrl != null)
//                {
//                    DeleteImage(hotel.ImageUrl);
//                }
//                hotel.ImageUrl = UploadImageAsync(hotel.Image).Result;
//            }
            

//            // if user inputs are valid then update hotel room details
//            _unitOfWork.Hotel.Update(hotel);
//            // update database
//            _unitOfWork.Save();
//            return RedirectToAction("Index", "Hotel");
//        }
//        // Post: /Hotel
//        // Delete and show the affect of the delete on the website homepage.
//        [HttpPost]
//        public async Task<IActionResult> Delete(int? id)
//        {

//            Hotel hotel = await _unitOfWork.Hotel.Get(h => h.Id == id);
//            // any edge case where the hotel room is not found? go directly to this page without hotel room?
//            if (hotel == null)
//            {
//                TempData["Error"] = "The hotel room you are trying to delete does not exist.";

//                return RedirectToAction("Error", "Home");
//            }

//            // Delete this hotel also deletes the image associated with it
//            if (hotel.ImageUrl != null) {
//                DeleteImage(hotel.ImageUrl);
//            }
//            _unitOfWork.Hotel.Remove(hotel);
//            _unitOfWork.Save();
//            TempData["Success"] = hotel.Name + " has been deleted successfully.";
//            return RedirectToAction("Index", "Hotel");

//        }
//        // Method to upload the image and return the image URL
//        private async Task<string> UploadImageAsync(IFormFile image)
//        {
//            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"assets\img\Hotel");
//            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
//            string filePath = Path.Combine(imagePath, fileName);

//            // Ensure the directory exists
//            if (!Directory.Exists(imagePath))
//            {
//                Directory.CreateDirectory(imagePath);
//            }

//            using (var fileStream = new FileStream(filePath, FileMode.Create))
//            {
//                await image.CopyToAsync(fileStream);
//            }

//            return @"\assets\img\Hotel\" + fileName;
//        }

//        // Method to delete the image based on its URL
//        private void DeleteImage(string imageUrl)
//        {
            
//            if (!string.IsNullOrEmpty(imageUrl))
//            {
//                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('\\'));
//                if (System.IO.File.Exists(imagePath))
//                {
//                    System.IO.File.Delete(imagePath);
//                }
//            }
//        }
//    }
//}
