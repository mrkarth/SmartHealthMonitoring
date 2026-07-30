namespace SmartHealth.API.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }

        //Navigation Property

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
