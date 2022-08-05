using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        [ForeignKey("roleID")]
        public Guid? roleID { get; set; }
        public virtual Role? role { get; set; }
    }
}