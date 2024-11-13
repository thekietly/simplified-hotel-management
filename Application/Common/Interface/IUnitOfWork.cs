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
        // Save changes to the database asynchronously
        void Save();
    }
}
