namespace MainAPI.Models
{
    public class Role
    {
        public int? Id { get; set; }

        public bool CanViewAllUsers { get; set; }

        public bool isAdmin { get; set; }
        
    }
}