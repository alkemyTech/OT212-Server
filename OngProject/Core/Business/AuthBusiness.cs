using Microsoft.IdentityModel.Tokens;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IEmailServices _emailServices;

        public AuthBusiness(UnitOfWork unitOfWork, IEmailServices emailServices)
        {
            _unitOfWork = unitOfWork;
            _emailServices = emailServices;
        }

        public async Task<UserDto> Register(RegisterDto registerUser)
        {
            //User already exist
            if (await Exist(registerUser.Email))
                return null;

            var user = registerUser.ToUserModel();
            
            //Get an add image url.
            if (registerUser.Photo != null)
                user.Photo = await ImageUploadHelper.UploadImageToS3(registerUser.Photo);

            user.Password = EncryptHelper.GetSHA256(user.Password); //Encriptamos la contraseña
            user.RoleId = 2; //Rol de usuario

            await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            var emailText = EmailHelper.GetWelcomeEmail();
            await _emailServices.SendEmailAsync(user.Email, "Bienvenido", emailText);

            return user.ToUserDto();
        }

        public async Task<string> Login(LoginDto userDto)
        {
            var user = await Verify(userDto.Email, userDto.Password);

            if (user != null)
                return GenerateToken(user);
            else
                throw new KeyNotFoundException("El mail y/o la contraseña son incorrectas.");
        }

        //This method is implemented after passing the QueryProperty branch
        private async Task<bool> Exist(string email)
        {
            var query = new QueryProperty<User>(1, 1);
            query.Where = x => x.Email == email;

            var user = await _unitOfWork.UserRepository.GetAsync(query);
            return user != null;
        }

        private async Task<User> Verify(string email, string password)
        {
            var query = new QueryProperty<User>(1, 1);
            var passwordHash = EncryptHelper.GetSHA256(password);

            query.Where = x => (x.Email == email)
            && (x.Password == passwordHash);
            query.Includes.Add(x => x.Roles);

            var user = await _unitOfWork.UserRepository.GetAsync(query);
            return user;
        }

        private string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("AppSetings:Token");

            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Roles.Name));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createdToken);
            return token;
        }
    }
}
