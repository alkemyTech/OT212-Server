using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
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

        public async Task<List<Contact>> GetAll()
        {
            var contactList = await _unitOfWork.ContactRepository.GetAllAsync();
            return contactList;
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
