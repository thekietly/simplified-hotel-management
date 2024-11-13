using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUnitOfWork
    {
        public IHotelRepository Hotel { get; }
        Task Save();
    }
}
