namespace MainAPI.Models
{
    public class RegisterDTO
    {
        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public string? passwordConfirmation { get; set; }
    }
}