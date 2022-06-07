using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class SlideDTO
    {
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }


    public class SlideInsertDto
    {
        public int? Order { get; set; }

        [Required(ErrorMessage = "You must enter a text!"), StringLength(65535)]
        public string Text { get; set; }

        [Required(ErrorMessage = "You must enter an image!")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "You must enter an organization id!")]
        public int OrganizationId { get; set; }
    }

    public class SlideDetailsDto : SlideDTO
    {     
        public string Text { get; set; }
        public OrganizationDto Organization { get; set; }
    }
}
