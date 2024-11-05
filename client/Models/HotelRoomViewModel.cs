using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace client.Models
{
    public class HotelRoomViewModel
    {
        public HotelRoom HotelRoom{ get; set; }
        public List<SelectListItem> Hotels { get; set; }
    }
}
