using client.Models;
using Domain.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> Index()
        {
            var hotelRooms = await _db.HotelRooms.Include(h => h.Hotel).ToListAsync();

            return View(hotelRooms);
        }

        // GET: HotelRoom/Update/5
        public ActionResult Update(int roomId, int hotelId)
        {
            // Retrieve the hotel room with the given id from the database
            var hotelRoom = _db.HotelRooms.FirstOrDefault(hr => hr.RoomId == roomId && hr.HotelId == hotelId);
            if (hotelRoom == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(hotelRoom);
        }
        // POST: HotelRoom/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(HotelRoomViewModel hotelRoomViewModel)
        {
            try
            {
                // update hotel room in the database
                _db.HotelRooms.Update(hotelRoomViewModel.HotelRoomVM);
                // update database
                _db.SaveChanges();


                return RedirectToAction("Index", "HotelRoom");
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelRoom/Create
        public ActionResult Create()
        {
            // Retrieve all hotels from the database
            var hotels = _db.Hotels.ToList();
            // Turn this hotels into a select list
            var hotelSelectList = hotels.Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            });

            // Add the select list to the view model
            // Initialize the HotelRoom object as it can't be null
            var hotelRoomViewModel = new HotelRoomViewModel
            {

                HotelList = hotelSelectList,
                HotelRoomVM = new HotelRoom()
            };

            // Pass the view model to the view
            return View(hotelRoomViewModel);
        }

        // POST: HotelRoom/Create
        [HttpPost]

        public ActionResult Create(HotelRoomViewModel hotelRoomView)
        {
            try
            {
                // add hotel room from the view model to the database
                _db.HotelRooms.Add(hotelRoomView.HotelRoomVM);
                // update database
                _db.SaveChanges();
                return RedirectToAction("Index", "HotelRoom");
            }
            catch (Exception e){
                // If something goes wrong, return this model state with the message. Then go back to the create page.
                ModelState.AddModelError(string.Empty, "An unexpected error occurred: " + e.Message + "\nPlease contact the IT support for additional help! Sorry for the inconvenience. :(");
                return RedirectToAction("Error", "Home"); ;  
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
