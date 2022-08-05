namespace MainAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public bool CanViewAllUsers { get; set; }

        public bool isRoleAdmin { get; set; }

    }
}