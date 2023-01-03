using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Models;

namespace WebNewsApp.Controllers
{
    public class AuthorizationController
    {
        private readonly IAuthorizationService _service;
        public AuthorizationController(IAuthorizationService service)
        {
            _service = service;
        }

        public UserViewModel Register(UserViewModel user)
        {
            var userDTO = new UserDTO()
            {
                Password = user.Password,
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Description = user.Description,
            };
            try
            {
                _service.Register(userDTO);
                user.Id = _service.FindByLogin(userDTO.Login).Id;
            }
            catch (ValidationException ex)
            {
                user.ErrorStatus = ex.Message;
            }
            return user;
        }
        public UserViewModel LogIn(string login, string password)
        {
            UserDTO userDTO;
            var user = new UserViewModel(); 
            try 
            { 
                userDTO = _service.Login(login, password); 
            }
            catch(ValidationException ex)
            {
                user.ErrorStatus = ex.Message;
                return user;
            }
            
            user.Id = userDTO.Id;
            user.Email = userDTO.Email;
            user.Login = userDTO.Login;
            user.Name = userDTO.Name;
            user.Surname = userDTO.Surname;
            user.Password = userDTO.Password;
            user.Description = userDTO.Description;
            user.RegisterDate = userDTO.RegisterDate;

            return user;
        }
    }
}
