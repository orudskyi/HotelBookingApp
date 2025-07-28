using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int MaxOccupancy { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
    }
}