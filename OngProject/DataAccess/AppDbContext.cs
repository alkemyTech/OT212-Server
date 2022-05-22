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

        public DbSet<Role> Roles { get; set; }

        public DbSet<Categories> Categories { get; set; }        
        public DbSet<News> NewsSet { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Slide> Slides { get; set; }


    }
}
