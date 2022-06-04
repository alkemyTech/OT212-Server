using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class TestimonialMapper
    {
        public static Testimonial MapToTestimonialEntity(this TestimonialCreationDto dto)
            => new Testimonial { 
                Name = dto.Name,
                Content = dto.Content,
                Image = ""
            };

        public static TestimonialDto MapToTestimonialDto(this Testimonial entity)
            => new TestimonialDto { 
                Id = entity.Id,
                Name = entity.Name,
                Content = entity.Content,
                ImageUrl = entity.Image
            };
    }
}
