using Microsoft.EntityFrameworkCore;
using STDem0.Models;

namespace STDem0.Data
{
    public class ITIContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
		public DbSet<User> Users { get; set; }
		public ITIContext(DbContextOptions options) : base(options) { }
        public ITIContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=mvcs;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
