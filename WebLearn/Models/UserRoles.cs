namespace WebLearn.Models
{
    public class UserRoles
    {
        public int UserRolesId { get; set; }
        public ICollection<Users> Users { get;} = new List<Users>();
        public ICollection<Roles> Roles { get;} = new List<Roles>();

}
