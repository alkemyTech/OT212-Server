using System;

namespace OngProject.Core.Models.DTOs
{
    public class ContactDto : Dto
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
