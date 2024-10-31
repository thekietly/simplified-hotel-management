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

        //[HttpPost]
        //public IActionResult Update(HotelRoom hotelRoom)
        //{
        //    if (hotelRoom.Name == hotelRoom.Description)
        //    {
        //        // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
        //        ModelState.AddModelError("Name", "Please be creative! The room's name cannot be the same as its description.");
        //    }
        //    // if model is not entered correctly return view
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    // if user inputs are valid then add hotel room to database
        //    _db.HotelRooms.Add(hotelRoom);
        //    // update database
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "HotelRoom");
        //}
    }
}
