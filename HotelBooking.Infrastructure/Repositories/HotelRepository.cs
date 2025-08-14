using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.AsNoTracking().ToListAsync();
        }

        public async Task<Hotel?> GetHotelByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }
    }
}