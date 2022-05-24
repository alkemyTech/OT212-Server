using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Testimonial : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(65535)]
        public string Content { get; set; }
    }
}