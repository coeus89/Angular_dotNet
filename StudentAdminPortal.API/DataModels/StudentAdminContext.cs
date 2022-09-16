using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.DataModels
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }  // differs from tutorial (Student)
        public DbSet<Gender> Genders { get; set; }  // differs from tutorial (Gender)
        public DbSet<Address> Addresses { get; set; }  // differs from tutorial (Address)
    }
}
