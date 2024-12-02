using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    // A central point for accessing all repositories
    public interface IUnitOfWork
    {
        // Provide access to the hotel repository
        public IHotelRepository Hotel { get; }
        // Provide access to the hotel room repository
        public IHotelRoomRepository HotelRoom { get; }
        // Provide access to the amenity repository
        public IHotelAmenityRepository HotelAmenity { get; }
        public IRoomAmenityRepository RoomAmenity { get; }
        public IAmenityRepository Amenity { get; }
        public IHotelImageGalleryRepository HotelImageGallery { get; }  

        // Save changes to the database asynchronously
        void Save();
    }
}
