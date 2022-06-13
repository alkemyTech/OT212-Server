using Microsoft.AspNetCore.Http;
using OngProject.Core.Helper;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class ActivityInsertDto
    {

        /// <summary>
        /// Nombre de la actividad.
        /// </summary>
        [Required()]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Contenido de la actividad.
        /// </summary>
        [Required()]
        [StringLength(65535)]
        public string Content { get; set; }

        /// <summary>
        /// Información de la imagen.
        /// </summary>
        [Required()]
        [ValidateAsImage]
        public IFormFile Image { get; set; }
    }
}
