using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
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

        public async Task<List<UserDto>> GetAll()
        {
            var userList = await _unitOfWork.UserRepository.GetAllAsync();
            return userList.Select(x => UserMapper.ToUserDto(x)).ToList();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var query = new QueryProperty<User>(1,1);
                query.Where = x => x.Email == email;

            return await _unitOfWork.UserRepository.GetAsync(query);
        }
    }
}