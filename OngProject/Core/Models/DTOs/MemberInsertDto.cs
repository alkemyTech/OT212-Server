using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class MemberInsertDto 
    {
        [Required]
        public string Name { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public IFormFile Image { get; set; }

        public string Description { get; set; }
    }
}
