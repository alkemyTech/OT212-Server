using System.Threading.Tasks;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBussines
    {
        Task<int> CountElements();
        Task<TestimonialDto> GetById(int id);
        Task<PageList<TestimonialDto>> GetAll(int page, int pageSize, string url);
        Task<Response<TestimonialDto>> Insert(TestimonialCreationDto creationDto);
        Task Update(Testimonial entity);
        Task<Response<TestimonialDto>> Delete(int id);
    }
}
