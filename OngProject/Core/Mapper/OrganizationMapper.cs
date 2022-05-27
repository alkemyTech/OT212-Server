using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class OrganizationMapper
    {
        public static OrganizationDto MapToOrganizationDto(this Organization entity)
            => new OrganizationDto{
                Id= entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                Phone = entity.Phone,
                Image = entity.Image
            };
    }
}
