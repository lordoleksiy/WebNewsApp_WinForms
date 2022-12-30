using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.DAL.Models;
using WebNewsApp.DAL.Repositories;

namespace WebNewsApp.BLL.Services
{
    public class UserManagerService : AutoMapperService, IUserManagerService
    {
        private readonly EFUnitOfWork UnitOfWork;
        public UserManagerService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
            if (user == null) throw new ValidationException("No user is found!");
            var userDTO = UserMapper.Map<UserDTO>(user);
            userDTO.Password = null;
            return userDTO;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return UserMapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(UnitOfWork.UserRepository.GetAll());
        }

        public void Update(UserDTO user)
        {
            if (user == null) throw new ValidationException("No data for register!");
            var userDal = UnitOfWork.UserRepository.GetById(user.Id);
            if (userDal == null) throw new ValidationException("No such user!");

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
