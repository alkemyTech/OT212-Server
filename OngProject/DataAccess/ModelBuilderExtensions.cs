using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Entity<User>()
                .HasData(
                //Role:Admin
                new User { Id = 1, FirstName = "María", LastName = "Hernandez", Email = "prueba1@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 2, FirstName = "José", LastName = "Gimenez", Email = "prueba2@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 3, FirstName = "Esteban", LastName = "Luciano", Email = "prueba3@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 4, FirstName = "Joaquin", LastName = "Mercedez", Email = "prueba4@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 5, FirstName = "Sofía", LastName = "García", Email = "prueba5@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 6, FirstName = "Franco", LastName = "Caseres", Email = "prueba6@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 7, FirstName = "Enrique", LastName = "Rossi", Email = "prueba7@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 8, FirstName = "Catalina", LastName = "Fernandez", Email = "prueba8@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 9, FirstName = "Julieta", LastName = "Rodriguez", Email = "prueba9@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 10, FirstName = "Camila", LastName = "Swartz", Email = "prueba10@gmail.com", Password = "1234", Photo = null, RoleId = 1, LastModified = System.DateTime.Now, IsDeleted = false },

                //Role:User
                new User { Id = 11, FirstName = "Carlos", LastName = "Gimenez", Email = "prueba11@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 12, FirstName = "Florencia", LastName = "Fernandez", Email = "prueba12@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 13, FirstName = "Juan", LastName = "Liwens", Email = "prueba13@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 14, FirstName = "Camilo", LastName = "Quinteros", Email = "prueba14@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 15, FirstName = "Ruby", LastName = "Llano", Email = "prueba15@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 16, FirstName = "Gabriela", LastName = "Martinez", Email = "prueba16@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 17, FirstName = "Luis", LastName = "Peralta", Email = "prueba17@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 18, FirstName = "Lucas", LastName = "Rappone", Email = "prueba18@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 19, FirstName = "Claudio", LastName = "Villareal", Email = "prueba19@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false },
                new User { Id = 20, FirstName = "Nicolas", LastName = "Ferrari", Email = "prueba20@gmail.com", Password = "1234", Photo = null, RoleId = 2, LastModified = System.DateTime.Now, IsDeleted = false }
                ) ;

            //Roles
            modelBuilder.Entity<Role>()
                .HasData(
                new Role { Id = 1, Name = "Administrador", Description = "Cuenta con accesos a mayores funcionalidades de la página", LastModified=System.DateTime.Now, IsDeleted=false},
                new Role { Id = 2, Name = "Usuario", Description = "Cuenta con accesos básicos de la página", LastModified=System.DateTime.Now, IsDeleted=false}
                );
        }
    }
}
