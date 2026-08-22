namespace SmartHealth.API.Entities
{
    public class HealthWorker
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string FacilityName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        //Navigation Property
        public User User { get; set; } = null!;
    }
}
