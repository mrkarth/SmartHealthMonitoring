using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartHealth.API.Data;
using SmartHealth.API.DTOs.Authentication;
using SmartHealth.API.Entities;
using SmartHealth.API.Security;
using SmartHealth.API.Services.Interfaces;
using System.Security.Cryptography;


namespace SmartHealth.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(ApplicationDbContext context, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;

        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email or Password.");
            }

            if (!user.IsActive)
            {
                throw new UnauthorizedAccessException("User account is inactive.");
            }
            var isPasswordValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid Email or Password.");
            }

            var accessToken = _jwtTokenService.GenerateAccessToken(user);
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.RefreshTokens.Add(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddMinutes(15)
            };

        }
    }
}
