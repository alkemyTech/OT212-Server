using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Activities")]
    public class Activity : Entity
    {
        [Required(ErrorMessage = "You must enter a name!"), Column(TypeName = "varchar"), StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a content!"), DataType(DataType.Text), StringLength(65535)]
        public string Content { get; set; }

        [Required(ErrorMessage = "You must enter an image!"), Column(TypeName = "varchar"), StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "You must enter a datetime!"), DataType(DataType.DateTime)]
        public DateTime DeletedAt { get; set; }
    }
}
