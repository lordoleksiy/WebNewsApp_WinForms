using System;
using System.Collections.Generic;
using System.Linq;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.DAL.Models;
using WebNewsApp.DAL.Repositories;

namespace WebNewsApp.BLL.Services
{
    public class AuthorizationService : AutoMapperService, IAuthorizationService
    {
        private readonly EFUnitOfWork UnitOfWork;
        private readonly UserValidator userValidator;

        public AuthorizationService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            userValidator = new UserValidator();
        }

        public UserDTO Login(string login, string password)
        {
            var userDAL = UnitOfWork.UserRepository.Find(u => u.Login.Equals(login)).FirstOrDefault();
            if (userDAL == null) throw new ValidationException("No user with such login!");
            if (!userDAL.Password.Equals(password)) throw new ValidationException("Password is incorrect!");
            
            return UserMapper.Map<UserDTO>(userDAL);
        }

        public void Register(UserDTO user)
        {
            if (user == null) throw new ValidationException("No data for register!");
            var testUser = UnitOfWork.UserRepository.Find(u => u.Login.Equals(user.Login) || u.Email.Equals(user.Email)).FirstOrDefault();
            if (testUser != null) throw new ValidationException("Account with such login or email is already registered");
            var results = userValidator.Validate(user);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    throw new ValidationException("Wrong Data!", error.PropertyName);
                }
            }
            var userDal = UserDalMapper.Map<User>(user);
            userDal.RegisterDate = DateTime.Now;
            UnitOfWork.UserRepository.Create(userDal);
            UnitOfWork.Save();
        }

        public UserDTO FindByLogin(string Login)
        {
            var user =  UnitOfWork.UserRepository.Find(u => u.Login.Equals(Login)).FirstOrDefault();
            if (user == null) throw new ValidationException("No user found!");
            return UserMapper.Map<UserDTO>(user);
        }
    }
}
