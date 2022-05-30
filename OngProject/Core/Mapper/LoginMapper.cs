using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class LoginMapper
    {
        public static LoginDto MapToUserDto(this User entity)
            => new LoginDto
            {
                Email = entity.Email,
                Password = entity.Password
            };
    }
}
