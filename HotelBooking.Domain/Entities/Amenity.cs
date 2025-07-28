using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
        
    }
}