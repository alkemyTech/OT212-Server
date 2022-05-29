using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
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

        //This method is implemented after passing the QueryProperty branch
        private async Task<bool> Exist(string email)
        {
            var query = new QueryProperty<User>(1, 1);
            query.Where = x => x.Email == email;

            var user =  await _unitOfWork.UserRepository.GetAsync(query);
            return user != null;
        }
    }
}
