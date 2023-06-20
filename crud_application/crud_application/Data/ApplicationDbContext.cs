using crud_application.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_application.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }  

        public DbSet<Employee> Employees { get; set; }
    }
}
