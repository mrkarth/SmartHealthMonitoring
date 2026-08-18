using SmartHealth.API.Entities;

namespace SmartHealth.API.Security
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user);
    }
}
