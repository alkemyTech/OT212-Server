using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Threading.Tasks;

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

        public async static Task<Slide> MapToSlideInsertDto(this SlideInsertDto entity)
            => new Slide
            {
                Order = entity.Order.GetValueOrDefault(),
                Text = entity.Text,
                OrganizationId = entity.OrganizationId,
                ImageUrl = await ImageUploadHelper.UploadImageToS3(entity.Image),
            };
    }
}
