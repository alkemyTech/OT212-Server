using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class CommentInsertDto
    {
        [Required]
        [StringLength(255)]
        public string Body { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int NewsId { get; set; }
    }

}
