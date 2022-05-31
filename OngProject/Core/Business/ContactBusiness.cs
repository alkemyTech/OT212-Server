using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactBusiness : IContactBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public ContactBusiness(UnitOfWork unitOfWor)
        {
            _unitOfWork = unitOfWor;
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

        public Task Insert(Contact entity)
        {
            throw new System.NotImplementedException();
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
