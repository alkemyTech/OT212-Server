using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        public readonly UnitOfWork _unitOfWork;

        public UserBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            return users;
        }

        public User GetById(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            return user;
        }

        public void Insert(User user)
        {
            _unitOfWork.UserRepository.Insert(user);
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }

        public void Delete(User user)
        {
            _unitOfWork.UserRepository.Delete(user);
        }
    }
}