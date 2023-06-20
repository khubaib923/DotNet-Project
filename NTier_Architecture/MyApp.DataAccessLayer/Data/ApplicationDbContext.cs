

using Microsoft.EntityFrameworkCore;
using NTier_Architecture.Models;

namespace NTier_Architecture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CategoryModel> Category { get; set; }
    }
}
