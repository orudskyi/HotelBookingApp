using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Hotels;
using HotelBooking.Application.Interfaces;

namespace HotelBooking.Api.Endpoints
{
    public static class HotelsEndpoints
    {
        public static void MapHotelEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/hotels").WithTags("Hotels");

            group.MapGet("/", async (IHotelRepository hotelRepository) =>
            {
                var hotels = await hotelRepository.GetAllHotelsAsync();

                var hotelDtos = hotels.Select(h => new HotelDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Rating = h.Rating,
                    City = h.Address?.City ?? String.Empty,
                    Country = h.Address?.Country ?? String.Empty
                });

                return Results.Ok(hotelDtos);
            });

            group.MapGet("{id:int}", async (int id, IHotelRepository hotelRepository) =>
            {
                var hotel = await hotelRepository.GetHotelByIdAsync(id);

                if (hotel is null)
                {
                    return Results.NotFound();
                }

                var hotelDto = new HotelDto
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Rating = hotel.Rating,
                    City = hotel.Address?.City ?? String.Empty,
                    Country = hotel.Address?.Country ?? String.Empty
                };

                return Results.Ok(hotelDto);
            });
        }
    }
}