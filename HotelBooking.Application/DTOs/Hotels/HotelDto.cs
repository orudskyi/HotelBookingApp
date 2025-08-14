namespace HotelBooking.Application.DTOs.Hotels
{
    public class HotelDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Rating { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}