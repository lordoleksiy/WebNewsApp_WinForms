using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;
using WebNewsApp.Models;

namespace WebNewsApp.Controllers
{
    public class UserManagerController
    {
        private readonly IUserManagerService _userManagerService;
        public UserManagerController(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        public UserViewModel UpdateUser(UserViewModel user)
        {
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                Description = user.Description
            };
            try
            {
                _userManagerService.Update(userDTO);
            }
            catch (Exception ex)
            {
                user.ErrorStatus = ex.Message;
            }
            return user;
        }
        public string DeleteUser(int id)
        {
            try
            {
            _userManagerService.Delete(id);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return null;
        }
        public UserViewModel FindUserByLogin(string login)
        {
            UserViewModel user = new UserViewModel();
            try
            {
                var userDTO = _userManagerService.FindByLogin(login);
                user = new UserViewModel()
                {
                    Id = userDTO.Id,
                    Login = userDTO.Login,
                    Email = userDTO.Email,
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Description = userDTO.Description
                };
            }
            catch(Exception ex)
            {
                user.ErrorStatus = ex.Message;
            }
            return user;
        } 
    }
}
