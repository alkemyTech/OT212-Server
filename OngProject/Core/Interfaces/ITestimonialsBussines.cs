using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBussines
    {
        public List<Testimonial> GetAll();
        public Testimonial GetById();
        public void Insert();
        public void Update();
        public void Delete();
    }
}
