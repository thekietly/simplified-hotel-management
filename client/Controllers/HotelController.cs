using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class HotelController : Controller
    {
        // database context
        private readonly ApplicationDbContext _db;

        public HotelController(ApplicationDbContext context)
        {
            _db = context;
        }
        // Get: /Hotel
        public IActionResult Index()
        {
            var hotel = _db.Hotels.ToList();
            return View(hotel);
        }

        // Get: /Hotel/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // Post: /Hotel/Create
        public IActionResult Create(Hotel hotel)
        {
            try {
                if (hotel.Name == hotel.Description)
                {
                    // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                    ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
                }
                // if not valid
                if (!ModelState.IsValid) {
                    return View(hotel);
                }
                // TODO: Check duplicate hotels.

                // if user inputs are valid then add hotel room to database
                _db.Hotels.Add(hotel);
                // update database
                _db.SaveChanges();
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

            Hotel hotel = _db.Hotels.FirstOrDefault(hr => hr.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotel == null)
            {
                // TODO: Try to find a way to trigger this edge case
                return NotFound();
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
                return View();
            }
            // if user inputs are valid then update hotel room details
            _db.Hotels.Update(hotel);
            // update database
            _db.SaveChanges();
            return RedirectToAction("Index", "Hotel");
        }
        // Post: /Hotel
        // Delete and show the affect of the delete on the website homepage.
        [HttpPost]
        public IActionResult Delete(int? id)
        {

            Hotel hotel = _db.Hotels.FirstOrDefault(hr => hr.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotel == null)
            {
                TempData["Error"] = "The hotel room you are trying to delete does not exist.";
                // TODO: Try to find a way to trigger this edge case
                return RedirectToAction("Error", "Home");
            }
            _db.Hotels.Remove(hotel);
            TempData["Success"] = hotel.Name + " has been deleted successfully.";
            _db.SaveChanges();
            return RedirectToAction("Index", "Hotel");

        }
    }
}
