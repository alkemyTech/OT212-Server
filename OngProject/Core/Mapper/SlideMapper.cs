using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class SlideMapper
    {
        public static SlideDTO MapToSlideDTO(this Slide entity)
            => new SlideDTO
            {
                ImageUrl = entity.ImageUrl,
                Order = entity.Order
            };
    }
}
