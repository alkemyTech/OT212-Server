using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Contact: Entity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public int Phone { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }
        [Required, MaxLength(65536)]
        public string Message { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
