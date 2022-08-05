namespace MainAPI.Models
{
    public class Role
    {
        public Guid? Id { get; set; }

        public bool CanViewAllUsers { get; set; }

        public bool isAdmin { get; set; }
        
    }
}