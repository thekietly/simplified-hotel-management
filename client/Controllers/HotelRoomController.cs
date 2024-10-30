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

                ModelState.AddModelError("", "Please be creative! The room's name cannot be the same as its description.");
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


    }
}
