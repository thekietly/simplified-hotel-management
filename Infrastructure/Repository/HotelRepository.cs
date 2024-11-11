using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Hotel entity)
        {
            _db.Add(entity);
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Hotel> query = _db.Set<Hotel>();
            // if filter is not null, apply the filter i.e h => h.Id == 1
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // if include properties is not null, include them i.e include(h => h.Hotel)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<Hotel> GetAll(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Hotel> query = _db.Set<Hotel>();
            // if filter is not null, apply the filter i.e h => h.Id == 1
            if (filter != null)
            {
                query


        }

        public void Remove(Hotel entity)
        {
            _db.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Hotel entity)
        {
            _db.Update(entity);
        }
    }
}
