using Microsoft.EntityFrameworkCore;
using UserManagemant.Database.Models;
using UserManagemant.Models;

namespace UserManagemant.Database
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=UserManage;User Id=postgres;Password=admin;");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
