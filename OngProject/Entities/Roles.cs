using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Roles : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
