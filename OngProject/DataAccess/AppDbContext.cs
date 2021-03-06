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
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.SeedUsers();

            modelBuilder.SeedCategories();

            modelBuilder.SeedActivities();

            modelBuilder.SeedTestimonials();

            modelBuilder.SeedNewsSet();

            modelBuilder.SeedMemebers();

            modelBuilder.SeedOrganization();

            modelBuilder.SeedSlides();
        }

    }
}
