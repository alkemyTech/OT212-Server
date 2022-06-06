using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class ContactDto : Dto
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(65536)]
        public string Message { get; set; }
    }
}
