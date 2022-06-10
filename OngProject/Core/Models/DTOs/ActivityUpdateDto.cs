using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using OngProject.Core.Helper;

namespace OngProject.Core.Models.DTOs
{
    public class ActivityUpdateDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(65535)]
        public string Content { get; set; }

        [ValidateAsImage]
        public IFormFile Image { get; set; }
    }
}
