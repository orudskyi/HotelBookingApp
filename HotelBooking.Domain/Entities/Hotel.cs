using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Address? Address { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        
    }
}