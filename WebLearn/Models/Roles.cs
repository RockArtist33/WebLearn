using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
