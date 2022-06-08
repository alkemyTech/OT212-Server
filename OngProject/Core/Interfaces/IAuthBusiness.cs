using OngProject.Core.Models.DTOs;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAuthBusiness
    {
        Task<UserDto> Register(RegisterDto registerUser);
        Task<string> Login(LoginDto userDto);
    }
}
