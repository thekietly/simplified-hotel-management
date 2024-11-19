using Application.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: AmenityController
        public ActionResult Index()
        {
            var amenities = _unitOfWork.Amenity.GetAll();
            return View();
        }

        // GET: AmenityController/Create
        public ActionResult Create()
        {
            return View();
        }


    }
}
