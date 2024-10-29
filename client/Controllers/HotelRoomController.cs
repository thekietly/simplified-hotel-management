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
    }
}
