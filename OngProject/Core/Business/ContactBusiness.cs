using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactBusiness : IContactBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailServices _emailServices;

        public ContactBusiness(UnitOfWork unitOfWor, IEmailServices emailServices)
        {
            _unitOfWork = unitOfWor;
            _emailServices = emailServices;
        }

        public async Task<List<ContactDto>> GetAll()
        {
            var contactList = await _unitOfWork.ContactRepository.GetAllAsync();

            return contactList.Select(x => ContactMapper.MapToContactDto(x)).ToList();
        }

        public Task<Contact> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(ContactDto entity)
        {
            try
            {
                var contact = new Contact 
                {
                    Name = entity.Name,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    Message = entity.Message,
                    DeletedAt = System.DateTime.Now
                };
                await _unitOfWork.ContactRepository.InsertAsync(contact);
                
                var emailTo = entity.Email;
                var subject = @$"{entity.Name} thanks for contact us.";
                var htmlContent = EmailHelper.GetNewContactEmail(entity.Name);
                var plainContent = $@"{entity.Name} thanks for contact us. We'll keep in touch.";

                await _emailServices.SendEmailAsync(emailTo, subject, htmlContent, plainContent);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ContactBusiness.Insert: {e.Message}");
            }
        }

        public Task Update(Contact entity)
        {
            throw new System.NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
