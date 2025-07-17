namespace HotelBooking.Application.DTOs.Auth
{
    public record RegisterUserDto(string Email, string Password, string FirstName, string LastName);
}