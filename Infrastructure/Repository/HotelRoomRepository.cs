﻿using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Data;


namespace Infrastructure.Repository
{
    public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelRoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
