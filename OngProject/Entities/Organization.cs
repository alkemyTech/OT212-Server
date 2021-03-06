using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Organizations")]
    public class Organization : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string WelcomeText { get; set; }

        [StringLength(2000)]
        public string AboutUsText { get; set; }

        [StringLength(500)]
        public string FacebookUrl { get; set; }

        [StringLength(500)]
        public string InstagramUrl { get; set; }

        [StringLength(500)]
        public string LinkedinUrl { get; set; }
    }
}
