namespace WebLearn.Models
{
    public class User_Roles
    {
        public int user_roles_Id { get; set; }
        public virtual Users user_id { get; set; }
        public virtual Roles role_id { get; set;}

    }
}
