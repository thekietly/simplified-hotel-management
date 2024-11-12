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
    public class HotelRepository :  Repository<Hotel>,IHotelRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Check if a hotel with the same name already exists
        public bool Exists(Hotel entity)
        {
            return _db.Hotels.Any(e => e.Name == entity.Name);
        }
    }
}
