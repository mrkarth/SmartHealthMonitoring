namespace SmartHealth.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int RoleId { get; set; }

        //Navigation Property
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public Role Role { get; set; } = null!;

        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public HealthWorker HealthWorker { get; set; } = null!;
    }
}
