using Microsoft.AspNetCore.Http;

namespace OngProject.Core.Models.DTOs
{
    public class CategoryInsertDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
