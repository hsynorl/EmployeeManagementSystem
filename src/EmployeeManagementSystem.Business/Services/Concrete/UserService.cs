using AutoMapper;
using Azure.Core;
using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Enums;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<IResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var user = mapper.Map<User>(createUserCommand);
            var result=await  userRepository.AddAsync(user);
            if (result>0)
            {
                return new SuccessResult("Kullanıcı eklendi");
            }
            return new ErrorResult("Kullanıcı eklenemedi");
        }

        public async Task<IResult> DeleteUser(DeleteUserCommand deleteUserCommand)
        {
            var user = await userRepository.GetSingleAsync(p => p.Id == deleteUserCommand.UserId);
            if (user == null) {
                return new ErrorResult("Kullanıcı bulunamadı");
            }
            var result=await userRepository.DeleteAsync(user);  
            if (result>0)
            {

                return new SuccessResult("Kullanıcı silindi");
            }
            return new ErrorResult("Kullanıcı silinemedi");
        }

        public async Task<IDataResult<List<UserViewModel>>> GetUsers()
        {
            var result = await userRepository.GetList(p => p.UserType == UserType.User);
            if (result.Count < 1)
            {
                return new ErrorDataResult<List<UserViewModel>>("Kullanıcı bulunamadı");
            }
            var users=mapper.Map<List<UserViewModel>>(result);  
            return new SuccessDataResult<List<UserViewModel>>(users);       
        }

        public async Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand)
        {
            var user= await userRepository.GetSingleAsync(p => p.EmailAddress == loginCommand.Email);

            if (user is null)
            {
                return new ErrorDataResult<LoginViewModel>("Kullanıcı bulunamadı");
            }
            if (user.Password!=loginCommand.Password)
            {
                return new ErrorDataResult<LoginViewModel>("Parola hatalı");
            }
            var loginViewModel = CreateLoginViewModel(user);

            return new SuccessDataResult<LoginViewModel>(loginViewModel);
        }
        
        private LoginViewModel CreateLoginViewModel(User user)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.EmailAddress),
        new Claim(ClaimTypes.GivenName, user.FirstName),
        new Claim(ClaimTypes.Surname, user.LastName),
        new Claim(ClaimTypes.Role, user.UserType.ToString())
    };

            var token = GenerateToken(claims);

            return new LoginViewModel
            {
                Token = token.Item1,
                TokenExpire = token.Item2
            };
        }

        private (string, DateTime) GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfig:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.Now.AddDays(10);
            var expiry = new DateTime(expiryDate.Year, expiryDate.Month, expiryDate.Day, expiryDate.Hour, expiryDate.Minute, expiryDate.Second);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry);
        }
        public async Task<IResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var user = await userRepository.GetSingleAsync(p => p.Id == updateUserCommand.UserId);
            if (user == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");
            }
            mapper.Map(updateUserCommand, user);
            var result=await userRepository.UpdateAsync(user);
            if (result>0) {
                return new SuccessResult("Kullanıcı güncellendi");
            }
            return new ErrorResult("Kullanıcı güncellenemedi");
        }
    }
}
