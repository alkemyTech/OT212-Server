using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryNameDTO MapToCategoryNameDTO(this Category entity) => new CategoryNameDTO
        {
            Name = entity.Name,
        };
        public async static Task<Category> MapToCategoryInsertDto(this CategoryInsertDto dto) => new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            Image = await ImageUploadHelper.UploadImageToS3(dto.Image),
        };
    }
}