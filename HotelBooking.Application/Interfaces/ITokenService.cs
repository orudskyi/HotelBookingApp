using System.Security.Claims;

namespace HotelBooking.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IEnumerable<Claim> claims);
    }
}
