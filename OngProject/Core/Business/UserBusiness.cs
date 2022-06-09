using OngProject.Core.Helper;
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

        public async Task<UserDto> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            
            return user?.ToUserDto();
        }

        public Task Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Update(int id, UserEditDto entity)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if(user == null)
                return null;

            entity.ToUserModel(user);

            //Get an add image url.
            if (entity.Photo != null)
                user.Photo = await ImageUploadHelper.UploadImageToS3(entity.Photo);

            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return user.ToUserDto();
        }

        public async Task Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if(user == null)
                throw new KeyNotFoundException();

            await _unitOfWork.UserRepository.SoftDeleteAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var query = new QueryProperty<User>(1,1);
                query.Where = x => x.Email == email;

            return await _unitOfWork.UserRepository.GetAsync(query);
        }
    }
}