using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
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
    }
}
