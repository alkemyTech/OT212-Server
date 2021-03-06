using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class ActivityDto : Dto
    {
        [Required()]
        [StringLength(255)]
        public string Name { get; set; }

        [Required()]
        [StringLength(65535)]
        public string Content { get; set; }

        [Required()]
        public string Image { get; set; }
    }
}
