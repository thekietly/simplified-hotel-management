using Domain.Entities;

namespace client.Models
{
    public class HotelViewModel
    {
        // Hotel entity
        public Hotel? Hotel { get; set; }
        // List of amenities of this hotel
        public HotelAmenity? HotelAmenity { get; set; }
        // List of images of this hotel
        public IEnumerable<HotelImageGallery>? HotelImageGalleries { get; set; }
    }
}
