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
        // Save changes to the database asynchronously
        void Save();
    }
}
