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


        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasData(
                        new Category
                        {
                            Id = 1,
                            Name = "Deporte",
                            Description = "Es una actividad física que realiza una persona o grupo de personas siguiendo ciertas reglas" +
                            "y dentro de un espacio físico determinado.",
                            Image = "https://www.mundoprimaria.com/wp-content/uploads/2020/07/deporte.jpg"

                        },
                        new Category
                        {
                            Id = 2,
                            Name = "Salud",
                            Description = "Es un estado de bienestar o de equilibrio que puede ser visto a nivel subjetivo o a nivel objetivo.",
                            Image = "https://www.abc.com.py/resizer/ogCxa51MQh3-MCnaiz7Ah97gUjI=/fit-in/770x495/smart/arc-anglerfish-arc2-prod-abccolor.s3.amazonaws.com/public/UDY3PFCAT5FAHBLDJLGH5UHBJA.jpg"
                        },
                        new Category
                        {
                            Id = 3,
                            Name = "Entretenimiento",
                            Description = "Es cualquier actividad que permite al ser humano emplear su tiempo para divertirse o recrear su ánimo" +
                            "con una distracción.",
                            Image = "https://www.pwc.com/mx/es/industrias/imagen/20210823-gemo-cap-mex-prev.jpg"
                        },
                        new Category
                        {
                            Id = 4,
                            Name = "Noticia",
                            Description = "Es un relato o escrito sobre un hecho actual y de interés público, difundido a través de los diversos medios" +
                            "de comunicación social.",
                            Image = "https://i.pinimg.com/originals/d1/a7/ac/d1a7ac3331307067bd40f504170417f6.jpg"
                        },
                        new Category
                        {
                            Id = 5,
                            Name = "Convivencia",
                            Image = "https://escuelacanariablog.files.wordpress.com/2018/09/mundo_nic3b1os.jpg"
                        });
        }

        public static void SeedActivities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    Id = 1,
                    Name = "Programas Educativos",
                    Image = "ProgramasEducativos.png",
                    Content = "Mediante nuestros programas educativos, buscamos incrementar la capacidad intelectual, " +
                    "moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la " +
                    "sociedad a la que pertenecen."
                },
                new Activity
                {
                    Id = 2,
                    Name = "Apoyo Escolar para el nivel Primario",
                    Image = "ApoyoPrimario.png",
                    Content = "El espacio de apoyo escolar es el corazón del área educativa. Se realizan los talleres " +
                    "de lunes a jueves de 10 a 12 horas y de 14 a 16 horas en el contraturno, Los sábados también se " +
                    "realiza el taller para niños y niñas que asisten a la escuela doble turno.Tenemos un espacio especial " +
                    "para los de 1er grado 2 veces por semana ya que ellos necesitan atención especial! Actualmente " +
                    "se encuentran inscriptos a este programa 150 niños y niñas de 6 a 15 años.Este taller está pensado " +
                    "para ayudar a los alumnos con el material que traen de la escuela, también tenemos una docente que " +
                    "les da clases de lengua y matemática con una planificación propia que armamos en Manos para nivelar " +
                    "a los niños y que vayan con más herramientas a la escuela."
                },
                new Activity
                {
                    Id = 3,
                    Name = "Apoyo Escolar Nivel Secundaria",
                    Image = "ApoyoSecundaria.png",
                    Content = "Del mismo modo que en primaria, este taller es el corazón del área secundaria.Se realizan " +
                    "talleres de lunes a viernes de 10 a 12 horas y de 16 a 18 horas en el contraturno.Actualmente se " +
                    "encuentran inscriptos en el taller 50 adolescentes entre 13 y 20 años.Aquí los jóvenes se presentan " +
                    "con el material que traen del colegio y una docente de la institución y un grupo de voluntarios los " +
                    "recibe para ayudarlos a estudiar o hacer la tarea.Este espacio también es utilizado por los jóvenes " +
                    "como un punto de encuentro y relación entre ellos y la institución."
                },
                new Activity
                {
                    Id = 4,
                    Name = "Tutorías",
                    Image = "Tutorías.png",
                    Content = "Es un programa destinado a jóvenes a partir del tercer año de secundaria, " +
                    "cuyo objetivo es garantizar su permanencia en la escuela y construir un proyecto de vida que " +
                    "da sentido al colegio.El objetivo de esta propuesta es lograr la integración escolar de niños " +
                    "y jóvenes del barrio promoviendo el soporte socioeducativo y emocional apropiado, desarrollando " +
                    "los recursos institucionales necesarios a través de la articulación de nuestras intervenciones " +
                    "con las escuelas que los alojan, con las familias de los alumnos y con las instancias municipales, " +
                    "provinciales y nacionales que correspondan.El programa contempla: \n" +
                    "● Encuentro semanal con tutores(Individuales y grupales) \n" +
                    "● Actividad proyecto(los participantes del programa deben pensar una actividad relacionada a lo " +
                    "que quieren hacer una vez terminada la escuela y su tutor los acompaña en el proceso) \n" +
                    "● Ayudantías(los que comienzan el 2do años del programa deben elegir una de las actividades " +
                    "que se realizan en la institución para acompañarla e ir conociendo como es el mundo laboral que " +
                    "les espera). \n" +
                    "● Acompañamiento escolar y familiar(Los tutores son encargados de articular con la " +
                    "familia y con las escuelas de los jóvenes para monitorear el estado de los tutorados) \n" +
                    "● Beca estímulo(los jóvenes reciben una beca estímulo que es supervisada por los tutores)." +
                    "Actualmente se encuentran inscriptos en el programa 30 adolescentes. \n" +
                    "● Taller Arte y Cuentos: Taller literario y de manualidades que se realiza semanalmente. \n" +
                    "● Paseos recreativos y educativos: Estos paseos están pensados para promover la participación y " +
                    "sentido de pertenencia de los niños, niñas y adolescentes al área educativa"
                });
        }

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
                );
        
            //Roles
            modelBuilder.Entity<Role>()
                .HasData(
                new Role { Id = 1, Name = "Administrador", Description = "Cuenta con accesos a mayores funcionalidades de la página", LastModified = System.DateTime.Now, IsDeleted = false },
                new Role { Id = 2, Name = "Usuario", Description = "Cuenta con accesos básicos de la página", LastModified = System.DateTime.Now, IsDeleted = false }
                );
        }
        public static void SeedTestimonials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial { Id = 1, Name = "Carlos", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 2, Name = "Florencia", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 3, Name = "Juan", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 4, Name = "Camilo", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 5, Name = "Luis", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 6, Name = "Gabrielo", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null },
                new Testimonial { Id = 7, Name = "Claudio", Content = "testimoniotestimoniotestimoniotestimoniotestimoniotestimonio", Image = null }
                );
        }
    }
}

