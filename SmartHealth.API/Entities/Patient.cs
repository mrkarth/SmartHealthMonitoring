namespace SmartHealth.API.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Navigation property
        public User User { get; set; } = null!;

        public ICollection<PatientDoctorAssignment> DoctorAssignments { get; set; } = new List<PatientDoctorAssignment>();

    }
}
