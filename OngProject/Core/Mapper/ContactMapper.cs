using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class ContactMapper
    {
        public static ContactDto MapToContactDto(this Contact entity)
        {
            return new ContactDto 
            { 
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                Message = entity.Message,
            };
        }
    }
}
