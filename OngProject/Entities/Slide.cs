using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Slides")]
    public class Slide : Entity
    {
        [Required(ErrorMessage = "You must enter an image!"), StringLength(255)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "You must enter a text!"), StringLength(65535), DataType(DataType.Text)]
        public string Text { get; set; }

        [Required(ErrorMessage = "You must enter an order!")]
        public int Order { get; set; }

        [Required(ErrorMessage = "You mush enter an organization id!"), ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}