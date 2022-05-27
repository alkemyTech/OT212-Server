using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void SeedNewsSet(this ModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Entity<News>()
                .HasData(
                new News { Id = 1, Name = "News 1", Content = "Content of news number 1", Image = "www.fakeurl.com/image1.jpg", CategoryId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new News { Id = 2, Name = "News 2", Content = "Content of news number 2", Image = "www.fakeurl.com/image1.jpg", CategoryId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new News { Id = 3, Name = "News 3", Content = "Content of news number 3", Image = "www.fakeurl.com/image1.jpg", CategoryId = 3, LastModified = System.DateTime.Now, IsDeleted = false },
                new News { Id = 4, Name = "News 4", Content = "Content of news number 4", Image = "www.fakeurl.com/image1.jpg", CategoryId = 4, LastModified = System.DateTime.Now, IsDeleted = false },
                new News { Id = 5, Name = "News 5", Content = "Content of news number 5", Image = "www.fakeurl.com/image1.jpg", CategoryId = 5, LastModified = System.DateTime.Now, IsDeleted = false });
        }
    }
}