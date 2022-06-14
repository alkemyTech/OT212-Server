using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class UserEditDto
    {
        /// <summary>
        /// Primer nombre del usuario a editar.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        /// <summary>
        /// Apellido del usuario a editar.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        /// <summary>
        /// Correo electrónico del usuario a editar.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        /// <summary>
        /// Imagen del usuario a editar.
        /// </summary>
        public IFormFile Photo { get; set; }

    }
}
