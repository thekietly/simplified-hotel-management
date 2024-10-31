using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class HotelRoomController : Controller
    {
        // database context
        private readonly ApplicationDbContext _db;

        public HotelRoomController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var hotelRooms = _db.HotelRooms.ToList();
            return View(hotelRooms);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelRoom hotelRoom)
        {
            if (hotelRoom.Name == hotelRoom.Description) {
                // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
                ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
            }
            // if model is not entered correctly return view
            if (!ModelState.IsValid)
            {
                return View();
            }
            // if user inputs are valid then add hotel room to database
            _db.HotelRooms.Add(hotelRoom);
            // update database
            _db.SaveChanges();
            return RedirectToAction("Index", "HotelRoom");
        }
        /*
         Purposes of Update method:
        1. Retrieve the hotel room with the given id from the database.
        2. If the hotel room is not found, return a 404 Not Found response.
        3. If the hotel room is found, return a view with the hotel room as the model.
         */
        public IActionResult Update(int? id) { 

            HotelRoom hotelRoom = _db.HotelRooms.FirstOrDefault(hr => hr.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotelRoom == null)
            {
                // TODO: Try to find a way to trigger this edge case
                return NotFound();
            }
            return View(hotelRoom);
        }

        [HttpPost]
        public IActionResult Update(HotelRoom hotelRoom)
        {
            if (hotelRoom.Name == hotelRoom.Description)
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
            _db.HotelRooms.Update(hotelRoom);
            // update database
            _db.SaveChanges();
            return RedirectToAction("Index", "HotelRoom");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {

            HotelRoom hotelRoom = _db.HotelRooms.FirstOrDefault(hr => hr.Id == id);
            // any edge case where the hotel room is not found? go directly to this page without hotel room?
            if (hotelRoom == null)
            {
                // TODO: Try to find a way to trigger this edge case
                return RedirectToAction("Error", "Home");
            }
            _db.HotelRooms.Remove(hotelRoom);
            _db.SaveChanges();
            return RedirectToAction("Index", "HotelRoom");

        }
    }
}
