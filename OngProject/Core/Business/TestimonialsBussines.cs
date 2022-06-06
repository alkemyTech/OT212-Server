using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
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

        public async Task<Response<TestimonialDto>> Insert(TestimonialCreationDto creationDto)
        {
            try
            {
                var testimonial = creationDto.MapToTestimonialEntity();

                if(creationDto.Image != null)
                    testimonial.Image = await ImageUploadHelper.UploadImageToS3(creationDto.Image);

                await _unitOfWork.TestimonialRepository.InsertAsync(testimonial);
                await _unitOfWork.SaveAsync();

                var testimonialDto = testimonial.MapToTestimonialDto();

                var response = new Response<TestimonialDto>
                {
                    Data = testimonialDto,
                    Succeeded = true,
                    Message = ResponseMessage.Success,
                    Errors = null
                };

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"TestimonialsBusiness.Insert: {ex.Message}");

                var response = new Response<TestimonialDto>
                {
                    Data = null,
                    Succeeded = false,
                    Message = ResponseMessage.Error,
                    Errors = new string[1] { "The insert can't be done." }
                };

                return response;
            }
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
