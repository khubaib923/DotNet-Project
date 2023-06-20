using CascadingDropdown.Models;
using Microsoft.EntityFrameworkCore;

namespace CascadingDropdown.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CountryModel> Countries { get; set; }  
        public DbSet<CityModel> Cities { get; set; }  
        public DbSet<AreaModel> Areas { get; set; }  




    }
}
