using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Slide> Slides { get; set; }
    }
}
