using AutoMapper;
using Azure.Core;
using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Enums;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
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
            if (result == null)
            {
                return new ErrorDataResult<List<UserViewModel>>("Kullanıcı bulunamadı");
            }
            var users=mapper.Map<List<UserViewModel>>(result);  
            return new SuccessDataResult<List<UserViewModel>>(users);       
        }

        public Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand)
        {
            throw new NotImplementedException();
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
