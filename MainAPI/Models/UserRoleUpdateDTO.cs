namespace MainAPI.Models
{
    public class UserRoleUpdateDTO
    {
        public string? email { get; set; }

        public Guid newRoleId { get; set; }
    }
}