using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interface
{
    public interface IHotelRepository
    {
        // Return all hotels
        IEnumerable<Hotel> GetAll(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null);
        Hotel Get(Expression<Func<Hotel, bool>> filter, string? includeProperties = null);

        // Mimic the CRUD operations in the controller
        // .Add a hotel
        void Add(Hotel entity);
        // .Update a hotel
        void Update(Hotel entity);
        // .Remove a hotel
        void Remove(Hotel entity);
        // .SaveChanges()
        void Save();
        bool Exists(Hotel entity);
    }
}
