//using Application.Common.Interface;
//using Domain.Entities;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace client.Controllers
//{
//    public class AmenityController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public AmenityController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        // GET: AmenityController
//        public async Task<IActionResult> Index()
//        {
//            var amenities = await _unitOfWork.Amenity.GetAll();
//            return View(amenities);
//        }
//        // GET: AmenityController/Update
//        public async Task<IActionResult> Update(int? id)
//        {

//            Amenity amenity= await _unitOfWork.Amenity.Get(a => a.Id == id);
//            // any edge case where the amenity is not found? go directly to this page without hotel room/hotel?
//            if (amenity == null)
//            {
//                TempData["Error"] = "The amenity you are trying to update does not exist.";
//                return RedirectToAction("Error", "Home");
//            }
//            return View(amenity);
//        }

//        [HttpPost]
//        // Post: /Amenity/Update/{id}
//        public IActionResult Update(Amenity amenity)
//        {
//            // if model is not entered correctly return view
//            if (!ModelState.IsValid)
//            {
//                // return view with the hotel room
//                return View(amenity);
//            }
//            // if user inputs are valid then update hotel room details
//            _unitOfWork.Amenity.Update(amenity);
//            // update database
//            _unitOfWork.Save();
//            return RedirectToAction("Index", "Amenity");
//        }
//        // GET: AmenityController/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: AmenityController/Create
//        [HttpPost]
//        public IActionResult Create(Amenity amenity)
//        {
//            try
//            {
//                // if not valid
//                if (!ModelState.IsValid)
//                {
//                    return View(amenity);
//                }
//                // Check if the amenity name already exists in the database
//                if (_unitOfWork.Amenity.Any(a => a.Name == amenity.Name))
//                {
//                    // key in AddModelError refers to the property in the model - in this case, error appears under the Name property
//                    ModelState.AddModelError("Name", "An amenity with the same name already exists.");
//                    return View(amenity);
//                }
//                // if user inputs are valid then add hotel room to database
//                _unitOfWork.Amenity.Add(amenity);
//                // update database
//                _unitOfWork.Save();
//                return RedirectToAction("Index", "Amenity");

//            }
//            catch
//            {
//                return RedirectToAction("Error", "Home");
//            }

//        }
//        // GET: AmenityController/Delete
//        [HttpPost]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            // Return the amenity with the given id
//            Amenity amenity = await _unitOfWork.Amenity.Get(a => a.Id == id);
//            // any edge case where the hotel room is not found? go directly to this page without hotel room?
//            if (amenity == null)
//            {
//                TempData["Error"] = "The amenity you are trying to delete does not exist.";

//                return RedirectToAction("Error", "Home");
//            }
//            _unitOfWork.Amenity.Remove(amenity);
//            _unitOfWork.Save();
//            TempData["Success"] = amenity.Name + " has been deleted successfully.";
//            return RedirectToAction("Index", "Amenity");
//        }
//    }
//}
