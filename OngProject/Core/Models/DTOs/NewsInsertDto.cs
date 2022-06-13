using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class NewsInsertDto
    {
        /// <summary>
        /// Nombre de la noticia.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// Contenido de la noticia.
        /// </summary>
        [Required]
        [StringLength(65535)]
        public string Content { get; set; }
        /// <summary>
        /// La imagen de la noticia.
        /// </summary>
        [Required]
        public IFormFile Image { get; set; }
        /// <summary>
        /// Id de la categoría a la que pertenece la noticia.
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
    }
}
