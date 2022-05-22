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
            var users = _unitOfWork.User.GetAll();
            return users;
        }

        public User GetById (int id)
        {
            var user = _unitOfWork.User.GetById(id);
            return user;
        }

        public void Insert(User user)
        {
            _unitOfWork.User.Insert(user);
        }

        public void Update(User user)
        {
            _unitOfWork.User.Update(user);
        }

        public void Delete(User user)
        {
            _unitOfWork.User.Delete(user);
        }
    }
}
