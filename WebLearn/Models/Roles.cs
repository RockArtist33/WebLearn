namespace WebLearn.Models
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserRolesId { get; set; }
        public UserRoles UserRoles { get; set; } = null;

    }
}
