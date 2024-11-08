using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace client.Models
{
    public class HotelRoomViewModel
    {
        public HotelRoom HotelRoomVM{ get; set; }
        public IEnumerable<SelectListItem> ?HotelList { get; set; }
        public IEnumerable<SelectListItem>? RoomTypeList { get; set; }
        public IEnumerable<SelectListItem>? BedTypeList { get; set; }
        // Constructor
        public HotelRoomViewModel()
        {
            // Initialize RoomTypeList and BedTypeList
            RoomTypeList = Enum.GetValues(typeof(RoomType))
                .Cast<RoomType>()
                .Select(r => new SelectListItem
                {
                    Text = r.ToString(),
                    Value = r.ToString()
                }).ToList();

            BedTypeList = Enum.GetValues(typeof(BedType))
                .Cast<BedType>()
                .Select(b => new SelectListItem
                {
                    Text = b.ToString(),
                    Value = b.ToString()
                }).ToList();
        }
    }
}
