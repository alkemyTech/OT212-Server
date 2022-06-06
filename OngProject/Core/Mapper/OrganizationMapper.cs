using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

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
                Image = entity.Image,
                FacebookUrl = entity.FacebookUrl,
                LinkedinUrl = entity.LinkedinUrl,
                InstagramUrl = entity.InstagramUrl,
            };

        public static OrganizationDetailsDto MapToOrganizationDetailsDto(this Organization entity, IEnumerable<SlideDTO> slides)
            => new OrganizationDetailsDto
               {
                   Id = entity.Id,
                   Name = entity.Name,
                   Address = entity.Address,
                   Phone = entity.Phone,
                   Image = entity.Image,
                   FacebookUrl = entity.FacebookUrl,
                   LinkedinUrl = entity.LinkedinUrl,
                   InstagramUrl = entity.InstagramUrl,
                   Slides = slides
               };
    }
}
