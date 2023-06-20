using Microsoft.EntityFrameworkCore;

namespace AspcoreLAB2.Models
{
    public class ITIContext :DbContext
    {
        public ITIContext() : base()
        {

        }
        //inject ask ioc container 
        public ITIContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MyTestMVC;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CursResult> Results { get; set; }




    }
}
