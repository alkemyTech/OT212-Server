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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }     
        public DbSet<News> NewsSet { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.SeedActivities();
            //Cargando datos
            modelBuilder.SeedUsers();


            modelBuilder.SeedCategories();

            modelBuilder.SeedUsers();

            modelBuilder.SeedActivities();

            modelBuilder.SeedTestimonials();

            modelBuilder.SeedNewsSet();
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
