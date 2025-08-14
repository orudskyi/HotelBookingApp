using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel?> GetHotelByIdAsync(int id);
    }
}