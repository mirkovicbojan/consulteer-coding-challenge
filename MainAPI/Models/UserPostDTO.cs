namespace MainAPI.Models
{
    public class UserPostDTO
    {
        public Guid Id { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public Guid roleID { get; set; }
    }
}