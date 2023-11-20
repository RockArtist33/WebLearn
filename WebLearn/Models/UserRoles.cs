using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRolesId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}
