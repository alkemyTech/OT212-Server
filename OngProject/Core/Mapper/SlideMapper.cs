using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class SlideMapper
    {
        public static SlideDTO MapToSlideDTO(this Slide entity)
            => new()
            {
                ImageUrl = entity.ImageUrl,
                Order = entity.Order
            };

        public static SlideDetailsDto MapToSlideDetailsDto(this Slide entity)
            => new()
            {
                ImageUrl = entity.ImageUrl,
                Order = entity.Order,
                Text = entity.Text,
                Organization = entity.Organization.MapToOrganizationDto(),
            };
    }
}
