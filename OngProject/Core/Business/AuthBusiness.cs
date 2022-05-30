using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Register(RegisterDto registerUser)
        {
            //User already exist
            if (await Exist(registerUser.Email))
                return null;

            var user = registerUser.ToUserModel();
            user.Password = EncryptHelper.GetSHA256(user.Password); //Encriptamos la contraseña
            user.RoleId = 2; //Rol de usuario

            await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            return user.ToUserDto();
        }

        public async Task<string> Login(LoginDto userDto)
        {
            var user = await Verify(userDto.Email, userDto.Password);
            string token = "token";

            if (user)
            {
                return token;
            }
            else
            {
                throw new KeyNotFoundException("El mail o la contraseña son incorrectas.");
            }
        }

        //This method is implemented after passing the QueryProperty branch
        private async Task<bool> Exist(string email)
        {
            var query = new QueryProperty<User>(1, 1);
            query.Where = x => x.Email == email;

            var user = await _unitOfWork.UserRepository.GetAsync(query);
            return user != null;
        }

        private async Task<bool> Verify(string email, string password)
        {
            var query = new QueryProperty<User>(1, 1);
            var passwordHash = EncryptHelper.GetSHA256(password);

            query.Where = x => (x.Email == email)
            && (x.Password == passwordHash);


            var user = await _unitOfWork.UserRepository.GetAsync(query);
            return user != null;
        }
    }
}
