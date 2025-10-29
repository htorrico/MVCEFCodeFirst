using Microsoft.EntityFrameworkCore;

namespace MVCEFCodeFirst.Models
{
    public class SchoolContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=HUGO\\SQLEXPRESS01;Database=Schoo2025lDb;" +
        //        "Integrated Security=true; trustservercertificate=True;");
        //}
        public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
        {
        }
    }
}
