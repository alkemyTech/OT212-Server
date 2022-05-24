using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class TestimonialsBussines : ITestimonialsBussines
    {
        private readonly UnitOfWork _unitOfWork;

        public TestimonialsBussines(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Testimonial> GetAll()
        {
            throw new NotImplementedException();
        }

        public Testimonial GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
