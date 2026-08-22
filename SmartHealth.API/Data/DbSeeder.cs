using Microsoft.EntityFrameworkCore;
using SmartHealth.API.Entities;
using SmartHealth.API.Security;

namespace SmartHealth.API.Data
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;

        public DbSeeder(
            ApplicationDbContext context,
            IPasswordHasher passwordHasher,
            IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task SeedAsync()
        {
            var roles = new[]
            {
                "Admin",
                "Doctor",
                "HealthWorker",
                "Patient"
            };

            foreach (var roleName in roles)
            {
                var roleExists = await _context.Roles
                    .AnyAsync(r => r.RoleName == roleName);

                if (!roleExists)
                {
                    _context.Roles.Add(new Role
                    {
                        RoleName = roleName
                    });
                }
            }

            await _context.SaveChangesAsync();

            var adminRole = await _context.Roles
                .FirstAsync(r => r.RoleName == "Admin");

            var adminEmail = _configuration["AdminSeed:Email"]
                ?? throw new InvalidOperationException(
                    "Admin email is not configured.");

            var adminPassword = _configuration["AdminSeed:Password"]
                ?? throw new InvalidOperationException(
                    "Admin password is not configured.");

            var adminExists = await _context.Users
                .AnyAsync(u => u.Email == adminEmail);

            if (!adminExists)
            {
                var passwordHash =
                    _passwordHasher.HashPassword(adminPassword);

                var admin = new User
                {
                    FirstName = "System",
                    LastName = "Admin",
                    Email = adminEmail,
                    PasswordHash = passwordHash,
                    PhoneNumber = "0000000000",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    RoleId = adminRole.Id
                };

                _context.Users.Add(admin);

                await _context.SaveChangesAsync();
            }
        }
    }
}