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
        public ActionResult Update(string roomId, int hotelId)
        {

            // Retrieve the hotel room with the given id from the database
            var hotelRoom = _db.HotelRooms.FirstOrDefault(hr => hr.RoomId == roomId && hr.HotelId == hotelId);
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
                HotelRoomVM = hotelRoom
            };
            if (hotelRoom == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(hotelRoomViewModel);
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
                //TODO [Feature]: Add validation to avoid duplicate room numbers in the same hotel


                if (hotelRoomView.HotelRoomVM.HotelId == 0)
                {
                    ModelState.AddModelError("", "Hotel number is required");
                    return View(hotelRoomView);
                }
                // Bind the hotel model to the hotel room model based on the selected hotel ID
                hotelRoomView.HotelRoomVM.Hotel = _db.Hotels.FirstOrDefault(h => h.Id == hotelRoomView.HotelRoomVM.HotelId);

                // After binding the hotel model to the hotel room model, the model is supposed to be valid
                if (!ModelState.IsValid)
                {
                    hotelRoomView.HotelList = _db.Hotels
                        .Select(h => new SelectListItem
                        {
                            Text = h.Name,
                            Value = h.Id.ToString()
                        }).ToList();
                    return View(hotelRoomView);
                }
                // add hotel room from the view model to the database
                _db.HotelRooms.Add(hotelRoomView.HotelRoomVM);
                // update database
                _db.SaveChanges();
                // Added a pop up message to show that the hotel room has been created successfully
                TempData["Success"] = hotelRoomView.HotelRoomVM.Name + " has been created successfully.";
                return RedirectToAction("Index", "HotelRoom");
            }
            catch (Exception e){
                // If something goes wrong, return this model state with the message. Then go back to the create page.
                ModelState.AddModelError(string.Empty, "An unexpected error occurred: " + e.Message + "\nPlease contact the IT support for additional help! Sorry for the inconvenience. :(");
                return RedirectToAction("Error", "Home"); ;  
            }
        }




        // POST: HotelRoom/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string roomId, int hotelId)
        {
            try
            {
                HotelRoom hotelRoom = _db.HotelRooms.FirstOrDefault(hr => hr.HotelId == hotelId && hr.RoomId == roomId);
                // any edge case where the hotel room is not found? go directly to this page without hotel room?
                if (hotelRoom == null)
                {
                    TempData["Error"] = "The hotel room you are trying to delete does not exist.";
                    // TODO: Try to find a way to trigger this edge case
                    return RedirectToAction("Error", "Home");
                }
                _db.HotelRooms.Remove(hotelRoom);
                TempData["Success"] = hotelRoom.Name + " has been deleted successfully.";
                _db.SaveChanges();
                return RedirectToAction("Index", "HotelRoom");

            }
            catch
            { 
                // Any other edge cases or unexpected behaviour would redirect users back to error page.
                return RedirectToAction("Error", "Home"); ;
            }
        }
    }
}
