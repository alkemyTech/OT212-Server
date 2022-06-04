using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class NewsDto : Dto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(65535)]
        public string Content { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

    }
}
