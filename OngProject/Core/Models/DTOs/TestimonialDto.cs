using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using OngProject.Core.Helper;

namespace OngProject.Core.Models.DTOs
{
    public class TestimonialCreationDto
    {
        [Required(ErrorMessage ="Name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Content is a required field.")]
        public string Content { get; set; }

        [ValidateAsImage]
        public IFormFile Image { get; set; }
    }

    public class TestimonialDto : Dto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
