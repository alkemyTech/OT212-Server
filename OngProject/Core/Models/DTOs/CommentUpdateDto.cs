using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class CommentUpdateDto
    {
        [Required]
        [StringLength(255)]
        public string Body { get; set; }
    }

}
