using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interface
{
    public interface IHotelRepository : IRepository<Hotel>
    {

        // .Update a hotel
        void Update(Hotel entity);

        // .Check if a hotel with the same name already exists
        bool Exists(Hotel entity);


    }
}
