using Domain.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        // GET: HotelRoom
        public ActionResult Index()
        {
            var hotelRooms = _db.HotelRooms.ToList();

            return View(hotelRooms);
        }

        // GET: HotelRoom/Update/5
        public ActionResult Update(int roomId, int hotelId)
        {
            return View();
        }
        // POST: HotelRoom/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(HotelRoom hotelRoom)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelRoom/Create
        public ActionResult Create()
        {
            var hotels = _db.Hotels.Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
            return View(hotels);
        }

        // POST: HotelRoom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelRoom hotelRoom)
        {

            
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



        // GET: HotelRoom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelRoom/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
