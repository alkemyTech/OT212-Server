using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsBussines : ITestimonialsBussines
    {
        private readonly UnitOfWork _unitOfWork;

        public TestimonialsBussines(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Testimonial>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Testimonial> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
