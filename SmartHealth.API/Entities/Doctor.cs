namespace SmartHealth.API.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string HospitalName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Navigation Property
        public User User { get; set; } = null!;
        public ICollection<PatientDoctorAssignment> PatientAssignments { get; set; } = new List<PatientDoctorAssignment>();
    }
}
