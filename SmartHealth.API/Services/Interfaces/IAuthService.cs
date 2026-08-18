using SmartHealth.API.DTOs.Authentication;

namespace SmartHealth.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
