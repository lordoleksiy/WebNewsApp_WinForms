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
    public class AuthorizationService : IAuthorizationService
    {
        private readonly EFUnitOfWork UnitOfWork;
        private readonly UserValidator userValidator;

        public AuthorizationService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            userValidator = new UserValidator();
        }
        public void Delete(int id)
        {
            if (UnitOfWork.UserRepository.GetById(id) == null) return;
            UnitOfWork.UserRepository.Delete(id);
            UnitOfWork.Save();
        }

        public UserDTO Find(int id)
        {
            var user = UnitOfWork.UserRepository.GetById(id);
            if (user == null) throw new ValidationException("No user is found!", "");
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Login = user.Login,
                Description = user.Description,
                RegisterDate = user.RegisterDate,
                Password = null,
            };
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return (IEnumerable<UserDTO>)UnitOfWork.UserRepository.GetAll();
        }

        public UserDTO Login(string login, string password)
        {
            var usersDAL = UnitOfWork.UserRepository.Find(u => u.Login.Equals(login));
            if (usersDAL == null) return null;
            var UserDTO = usersDAL.Select(
                u => new UserDTO 
                {
                    Id = u.Id, 
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    Login = u.Login,
                    Description = u.Description,
                    RegisterDate = u.RegisterDate,
                    Password = u.Password,
                }).First();
            if (UserDTO.Password.Equals(password))
            {
                return UserDTO;
            }
            return null;
        }

        public void Register(UserDTO user)
        {
            if (user == null) throw new ValidationException("No data for register!", "");
            var testUser = UnitOfWork.UserRepository.Find(u => u.Login.Equals(user.Login) || u.Email.Equals(user.Email));
            if (testUser.Count() > 0) throw new ValidationException("User is already registered", "");
            var results = userValidator.Validate(user);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    throw new ValidationException("Wrong Data!", error.PropertyName);
                }
            }
            var userDal = new User 
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                Description = user.Description,
                RegisterDate = new DateTime(),
            };
            UnitOfWork.UserRepository.Create(userDal);
            UnitOfWork.Save();
        }
        public void Update(UserDTO user)
        {
            if (user == null) throw new ValidationException("No data for register!");
            var userDal = UnitOfWork.UserRepository.GetById(user.Id);

            userDal.Name = user.Name;
            userDal.Surname = user.Surname;
            userDal.Email = user.Email;
            userDal.Login = user.Login;
            userDal.Description = user.Description;
            userDal.Password = user.Password;
            
            UnitOfWork.UserRepository.Update(userDal);
            UnitOfWork.Save();
        }
    }
}
