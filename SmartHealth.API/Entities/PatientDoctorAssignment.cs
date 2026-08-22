namespace SmartHealth.API.Entities
{
    public class PatientDoctorAssignment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        //Navigation Property
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}
