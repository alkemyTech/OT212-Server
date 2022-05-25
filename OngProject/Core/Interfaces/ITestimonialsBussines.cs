using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBussines
    {
        Task<List<Testimonial>> GetAll();
        Task<Testimonial> GetById(int id);
        Task Insert(Testimonial entity);
        Task Update(Testimonial entity);
        Task Delete(int id);
    }
}
