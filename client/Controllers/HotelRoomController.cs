using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class HotelRoomController : Controller
    {
        // GET: HotelRoom
        public ActionResult Index()
        {
            return View();
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
            return View();
        }

        // POST: HotelRoom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelRoom hotelRoom)
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
