using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}