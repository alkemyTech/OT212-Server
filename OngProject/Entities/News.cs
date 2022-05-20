using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class News : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(65535)]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        public int CategoryId { get; set; }

    }
}
