using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using OngProject.Core.Helper;

namespace OngProject.Core.Models.DTOs
{
    public class ActivityUpdateDto
    {
        /// <summary>
        /// Nombre de la actividad.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Contenido de la actividad.
        /// </summary>
        [Required]
        [StringLength(65535)]
        public string Content { get; set; }

        /// <summary>
        /// Información de la imagen.
        /// </summary>
        [ValidateAsImage]
        public IFormFile Image { get; set; }
    }
}
