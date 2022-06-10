using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Email = user.Email;
            userDto.Photo = user.Photo;

            return userDto;
        }

        public static User ToUserModel(this RegisterDto registerDto)
        {
            User user = new User();

            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.Password = registerDto.Password;
            user.Photo = registerDto.Photo?.FileName;

            return user;
        }

        public static User ToUserModel(this UserEditDto registerDto, User user)
        {
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.Photo = registerDto.Photo?.FileName;

            return user;
        }

        public static UserDto ToUserDto(this UserEditDto registerDto)
        {
            UserDto user = new UserDto();
            
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.Photo = registerDto.Photo?.FileName;

            return user;
        }
    }
}
