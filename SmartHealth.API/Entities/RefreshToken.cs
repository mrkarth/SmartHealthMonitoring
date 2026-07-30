using Microsoft.Identity.Client;

namespace SmartHealth.API.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreatedAt { get; set; }

        //Navigation Property
        public User User { get; set; } = null!;
    }
}
