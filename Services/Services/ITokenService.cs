using Domain.DTOs;

namespace Services.Services
{
    public interface ITokenService
    {
        string CreateToken(IUser user);
    }
}