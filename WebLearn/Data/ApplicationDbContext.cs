using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebLearn.Models;

namespace WebLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebLearn.Models.Assignments> Assignments { get; set; } = default!;
        public DbSet<WebLearn.Models.Attachments> Attachments { get; set; } = default!;
        public DbSet<WebLearn.Models.CalendarEvents> CalendarEvents { get; set; } = default!;
        public DbSet<WebLearn.Models.CourseAssignmentGrades> CourseAssignmentGrades { get; set; } = default!;
        public DbSet<WebLearn.Models.Courses> Courses { get; set; } = default!;
        public DbSet<WebLearn.Models.Grades> Grades { get; set; } = default!;
        public DbSet<WebLearn.Models.GradeTypes> GradeTypes { get; set; } = default!;
        public DbSet<WebLearn.Models.Roles> Roles { get; set; } = default!;
        public DbSet<WebLearn.Models.UserCalendar> UserCalendar { get; set; } = default!;
        public DbSet<WebLearn.Models.UserCourses> UserCourses { get; set; } = default!;
        public DbSet<WebLearn.Models.UserRoles> UserRoles { get; set; } = default!;
        public DbSet<WebLearn.Models.Users> Users { get; set; } = default!;
    }
}