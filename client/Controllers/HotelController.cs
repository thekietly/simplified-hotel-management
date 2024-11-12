using Application.Common.Interface;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class HotelController : Controller
    {
        // giving access to the hotel database collection via the IHotelRepository interface
        private readonly IHotelRepository _hotelRepository;

        
        public HotelController(IHotelRepository hotelRepository)
        {
            // Program.cs will inject the IHotelRepository into the HotelController
            // Logic in the HotelRepository class will be executed
            _hotelRepository = hotelRepository;
        }
        // Get: /Hotel
        public IActionResult Index()
        {
            // Ultilize the GetAll method from the IHotelRepository interface to get all hotels
            var hotels = _hotelRepository.GetAll();
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
                
                if (_hotelRepository.Exists(hotel))
                {
                    // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                    ModelState.AddModelError("Name", "A hotel with the same name already exists.");
                    return View(hotel);
                }

                // if user inputs are valid then add hotel room to database
                _hotelRepository.Add(hotel);
                // update database
                _hotelRepository.Save();
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
        public IActionResult Update(int? id) { 

            Hotel hotel = _hotelRepository.Get(h => h.Id == id);
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
            // if user inputs are valid then update hotel room details
            _hotelRepository.Update(hotel);
            // update database
            _hotelRepository.Save();
            return RedirectToAction("Index", "Hotel");
        }
        // Post: /Hotel
        // Delete and show the affect of the delete on the website homepage.
        [HttpPost]
        public IActionResult Delete(int? id)
        {

            Hotel hotel = _hotelRepository.Get(h => h.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotel == null)
            {
                TempData["Error"] = "The hotel room you are trying to delete does not exist.";

                return RedirectToAction("Error", "Home");
            }
            _hotelRepository.Remove(hotel);
            TempData["Success"] = hotel.Name + " has been deleted successfully.";
            _hotelRepository.Save();
            return RedirectToAction("Index", "Hotel");

        }
    }
}
