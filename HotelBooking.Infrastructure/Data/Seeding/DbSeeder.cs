using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Infrastructure.Data.Seeding
{
    public static class DbSeeder
    {
        public static IEnumerable<Hotel> GetHotels()
    {
        return new List<Hotel>
        {
            new Hotel
            {
                Id = 1,
                Name = "Grand Hyatt",
                Rating = 5,
                Address = new Address("Ukraine", "Kyiv", "Khreshchatyk St, 22", "01001")
            },
            new Hotel
            {
                Id = 2,
                Name = "Radisson Blu",
                Rating = 4,
                Address = new Address("Ukraine", "Lviv", "Halytska Square, 7", "79008")
            },
            new Hotel
            {
                Id = 3,
                Name = "Hilton",
                Rating = 5,
                Address = new Address("Ukraine", "Odesa", "Frantsuzkyi Blvd, 52", "65009")
            }
        };
    }
    }
}